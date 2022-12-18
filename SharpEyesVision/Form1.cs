using OpenCvSharp;
using OpenCvSharp.Extensions;
using Point = OpenCvSharp.Point;
using Size = OpenCvSharp.Size;

namespace SharpEyesVision
{
    public partial class Form1 : Form
    {
        private bool _liveRun = false;
        private bool _mainRun = false;
        private Mat templatePic;
        public Form1()
        {
            InitializeComponent();
        }


        void newLive(int index)
        {
            var capture = new VideoCapture(index);
            int sleepTime = (int)Math.Round(100 / capture.Fps);
            // 声明实例 Mat类
            Mat image = new Mat();
            // 进入读取视频每帧的循环
            while (_liveRun)
            {
                capture.Read(image);
                //判断是否还有没有视频图像 
                if (image.Empty())
                    break;
                // 在picturebox中播放视频， 需要先转换成bitmap格式
                cbdBox.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
                Cv2.WaitKey(sleepTime);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;//经典解决“线程间操作无效: 从不是创建控件的线程访问它”
            cbDevices.Items.Add("默认相机");
            cbDevices.SelectedIndex = 0;
            cbdBox.SizeMode = PictureBoxSizeMode.StretchImage;
            displayBox.SizeMode = PictureBoxSizeMode.StretchImage;
            templateBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void cbDevices_SelectionChangeCommitted(object sender, EventArgs e)
        {
            logBox.AppendText(cbDevices.SelectedIndex.ToString());
        }

        private void openCBD_Click(object sender, EventArgs e)
        {
            int cbd = cbDevices.SelectedIndex;
            if (openCBD.Text.Equals("打开相机"))
            {
                _liveRun = true;

                Thread liveThread = new Thread(() => newLive(cbd));
                liveThread.Start();

                openCBD.Text = "关闭相机";
            }
            else
            {
                _liveRun = false;
                cbdBox.Image = null;
                openCBD.Text = "打开相机";
            }
        }

        private string GetFilePath(string HistoryPath)
        {
            try
            {
                string FilePath = "";
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "请选择文件";
                dialog.Filter = "所有文件(*.*)|*.*";
                if (!string.IsNullOrWhiteSpace(HistoryPath)) dialog.FileName = HistoryPath.Trim();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = dialog.FileName;
                    if (string.IsNullOrWhiteSpace(FilePath))
                    {
                        MessageBox.Show(this, "文件路径不能为空", "提示");
                        return "";
                    }
                    else
                    {
                        return FilePath;
                    }
                }
                return FilePath;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.InnerException);
                return "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String path = GetFilePath(" ");
            logBox.AppendText("【设置模板】"+ path);
            templatePic = Cv2.ImRead(path);
            templateBox.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(templatePic);
        }

        class ResultPoint
        {
            public double X;   // 长度
            public double Y;  // 宽度
            public double T;   // 高度
            public double Score;   // 高度
            public ResultPoint() { }
            public ResultPoint(double x, double y, double t, double score)
            {
                X = (int)x;
                Y = (int)y;
                T = t;
                Score = score;
            }
        }
        static Point[] GetRotatePoints(Mat img, Rect inRect, double angle)
        {
            Rect rect = inRect;
            Point[] pts = new Point[4];
            Point2f center = new Point2f(img.Width / 2, img.Height / 2);
            Mat M = Cv2.GetRotationMatrix2D(center, angle, 1.0);
            //cout << M << endl;

            Mat ptMat = Mat.Ones(3, 4, MatType.CV_32FC1);
            ptMat.At<float>(0, 0) = 0;
            ptMat.At<float>(0, 1) = (float)rect.Width - 1;
            ptMat.At<float>(0, 2) = (float)rect.Width - 1;
            ptMat.At<float>(0, 3) = 0;
            ptMat.At<float>(1, 0) = 0;
            ptMat.At<float>(1, 1) = 0;
            ptMat.At<float>(1, 2) = (float)rect.Height - 1;
            ptMat.At<float>(1, 3) = (float)rect.Height - 1;

            M.ConvertTo(M, MatType.CV_32F);

            Mat result = M * ptMat;
            //cout << result << endl;
            pts[0] = new Point((int)result.At<float>(0, 0), (int)result.At<float>(1, 0));
            pts[1] = new Point((int)result.At<float>(0, 1), (int)result.At<float>(1, 1));
            pts[2] = new Point((int)result.At<float>(0, 2), (int)result.At<float>(1, 2));
            pts[3] = new Point((int)result.At<float>(0, 3), (int)result.At<float>(1, 3));
            return pts;
        }

        /// 图像旋转
        static Mat ImageRotate(Mat image, double angle)
        {
            Mat newImg = new Mat();
            Point2f pt = new Point2f((float)image.Cols / 2, (float)image.Rows / 2);
            Mat r = Cv2.GetRotationMatrix2D(pt, angle, 1.0);
            Cv2.WarpAffine(image, newImg, r, image.Size());

            return newImg;
        }

        /// 多角度模板匹配
        static ResultPoint CircleMatchNcc(Mat srcImage, Mat modelImage, double angleStart, double angleRange, double angleStep, int numLevels, double thresScore, int nccMethod)
        {
            double step = angleRange / ((angleRange / angleStep) / 100);
            double start = angleStart;
            double range = angleRange;

            int resultCols = srcImage.Cols - modelImage.Cols + 1;
            int resultRows = srcImage.Rows - modelImage.Cols + 1;
            Mat result = new Mat(resultCols, resultRows, MatType.CV_8U);
            Mat src = new Mat();
            Mat model = new Mat();
            srcImage.CopyTo(src);
            modelImage.CopyTo(model);

            for (int i = 0; i < numLevels; i++)
            {
                Cv2.PyrDown(src, src, new Size(src.Cols / 2, src.Rows / 2));
                Cv2.PyrDown(model, model, new Size(model.Cols / 2, model.Rows / 2));
            }

            TemplateMatchModes matchMode = TemplateMatchModes.CCoeffNormed;
            switch (nccMethod)
            {
                case 0:
                    matchMode = TemplateMatchModes.SqDiff;
                    break;
                case 1:
                    matchMode = TemplateMatchModes.SqDiffNormed;
                    break;
                case 2:
                    matchMode = TemplateMatchModes.CCorr;
                    break;
                case 3:
                    matchMode = TemplateMatchModes.CCorrNormed;
                    break;
                case 4:
                    matchMode = TemplateMatchModes.CCoeff;
                    break;
                case 5:
                    matchMode = TemplateMatchModes.CCoeffNormed;
                    break;
            }

            Cv2.MatchTemplate(src, model, result, matchMode);
            Cv2.MinMaxLoc(result, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc, new Mat());

            Point location = maxLoc;
            double temp = maxVal;
            double angle = 0;

            Mat newImg;

            if (nccMethod == 0 || nccMethod == 1)
            {
                do
                {
                    for (int i = 0; i <= (int)range / step; i++)
                    {
                        newImg = ImageRotate(model, start + step * i);
                        Cv2.MatchTemplate(src, newImg, result, matchMode);
                        Cv2.MinMaxLoc(result, out double minval, out double maxval, out Point minloc, out Point maxloc, new Mat());
                        if (maxval < temp)
                        {
                            location = maxloc;
                            temp = maxval;
                            angle = start + step * i;
                        }
                    }
                    range = step * 2;
                    start = angle - step;
                    step = step / 10;
                } while (step > angleStep);
                return new ResultPoint(location.X * Math.Pow(2, numLevels) + modelImage.Width / 2, location.Y * Math.Pow(2, numLevels) + modelImage.Height / 2, -angle, temp);
            }
            else
            {
                do
                {
                    for (int i = 0; i <= (int)range / step; i++)
                    {
                        newImg = ImageRotate(model, start + step * i);
                        Cv2.MatchTemplate(src, newImg, result, matchMode);
                        Cv2.MinMaxLoc(result, out double minval, out double maxval, out Point minloc, out Point maxloc, new Mat());
                        if (maxval > temp)
                        {
                            location = maxloc;
                            temp = maxval;
                            angle = start + step * i;
                        }
                    }
                    range = step * 2;
                    start = angle - step;
                    step = step / 10;
                } while (step > angleStep);
                if (temp > thresScore)
                {
                    return new ResultPoint(location.X * Math.Pow(2, numLevels), location.Y * Math.Pow(2, numLevels), -angle, temp);
                }
            }

            return new ResultPoint(-1, -1, 0, 0);
        }
        void newMain()
        {

            while (_mainRun)
            {
                Thread.Sleep((int)numericUpDown1.Value);
                Mat testPic = BitmapConverter.ToMat((Bitmap)cbdBox.Image);
          
                ResultPoint matchResult = new ResultPoint();
                matchResult = CircleMatchNcc(testPic, templatePic, (double)minNum.Value, (double)maxNum.Value,1,3, Convert.ToDouble(scoreNum.Text),5);
                Rect rect = new Rect((int)matchResult.X, (int)matchResult.Y, templatePic.Width, templatePic.Height);
                Point[] pts = GetRotatePoints(templatePic, rect, matchResult.T + 360);
                Point ptStart = new Point(rect.X, rect.Y);
                Cv2.Line(testPic, pts[0] + ptStart, pts[1] + ptStart, new Scalar(0, 255, 0), 2);
                Cv2.Line(testPic, pts[1] + ptStart, pts[2] + ptStart, new Scalar(0, 255, 0), 2);
                Cv2.Line(testPic, pts[2] + ptStart, pts[3] + ptStart, new Scalar(0, 255, 0), 2);
                Cv2.Line(testPic, pts[3] + ptStart, pts[0] + ptStart, new Scalar(0, 255, 0), 2);
                Cv2.Resize(testPic, testPic, new Size(), 0.5, 0.5);

                logBox.AppendText("x="+matchResult.X+",y=" + matchResult.Y + ",t=" + matchResult.T + ",score=" + matchResult.Score);

                displayBox.Image = BitmapConverter.ToBitmap(testPic);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openCBD.Text.Equals("打开相机"))
            {
                MessageBox.Show("请先打开相机");
                return;
            }

            if (button2.Text.Equals("运行"))
            {
                _mainRun = true;

                Thread mainThread = new Thread(() => newMain());
                mainThread.Start();

                button2.Text = "停止";
            }
            else
            {
                _mainRun = false;
                button2.Text = "运行";
            }
        }
    }
}