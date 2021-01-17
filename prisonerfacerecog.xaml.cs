using System;
using System.Collections.Generic;
using System.Windows;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Media;
using System.Windows.Interop;
using System.Data.SqlClient;
using JailManagementSystem.visitor;

namespace JailManagementSystem
{
    /// <summary>
    /// Interaction logic for prisonerfacerecog.xaml
    /// </summary>
    public partial class prisonerfacerecog : Window
    {
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        public string type;

        string name, names = null;

        bool frame_active = true;

        private void deten_recog_Click(object sender, RoutedEventArgs e)
        {
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            ComponentDispatcher.ThreadIdle += new EventHandler(FrameGrabber);
            deten_recog.IsEnabled = false;
        }

        private void face_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                //Trained face counter
                ContTrain = ContTrain + 1;

                //Get a gray frame from capture device
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new System.Drawing.Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                //resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(person_name.Text);

                //Show face added in gray scale
                train_image.Source = ImageSourceForBitmap(TrainedFace.ToBitmap());

                //Write the number of triained faces in a file text for further load
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                //Write the labels of triained faces in a file text for further load    
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save(AppDomain.CurrentDomain.BaseDirectory + "/TrainedFaces/face" + i + ".bmp");
                    File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }

                MessageBox.Show(person_name.Text + "´s face detected and added :)", "Training OK");
                
            }
            catch
            {
                MessageBox.Show("Enable the face detection first", "Training Fail");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void train_detect_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cons = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

            string query = "select * from " + type;
            SqlCommand coms = new SqlCommand(query, cons);
            SqlDbConnection con = new SqlDbConnection();

            cons.Open();
            //getting sql data from case registration prisoner to prisoner main
            SqlDataReader read = coms.ExecuteReader();

            string firstname;
            while (read.Read())
            {
                if (read["firstname"].ToString() == face_persons.Text.ToString())
                {

                    firstname = read["firstname"].ToString();
                    string identifier = read["id"].ToString();

                    frame_active = false;
                    MessageBox.Show("A face is detected");
                    this.Close();

                    if (type == "prisoner")
                    {
                        prisonermain pm = new prisonermain();
                    pm.Show();
                    pm.datagrid_prisoner.Visibility = Visibility.Hidden;
                    pm.edit.Visibility = Visibility.Visible;
                    pm.firstname.Text = read["firstname"].ToString();
                    pm.middlename.Text = read["middlename"].ToString();
                    pm.birthdate.Text = read["birthdate"].ToString();
                    pm.lastname.Text = read["lastname"].ToString();
                    pm.address.Text = read["address"].ToString();
                    pm.age.Text = read["age"].ToString();
                    pm.gender.Text = read["gender"].ToString();
                    pm.weight.Text = read["weight"].ToString();
                    pm.height.Text = read["height"].ToString();
                    pm.citizenship.Text = read["citizenship"].ToString();
                    pm.religion.Text = read["religion"].ToString();
                    pm.datein.Text = read["datein"].ToString();
                    pm.civilstatus.Text = read["civilstatus"].ToString();
                    pm.jailstatus.Text = read["jailstatus"].ToString();
                    }

                    if (type == "visitor")
                    {
                        visitormain pm = new visitormain();
                        pm.Show();
                        pm.datagrid_visitor.Visibility = Visibility.Hidden;
                        pm.edit_visitor.Visibility = Visibility.Visible;
                        pm.id.Text = read["id"].ToString();
                        pm.relation.Text = read["relation"].ToString();
                        pm.lastname.Text = read["lastname"].ToString();
                        pm.firstname.Text = read["firstname"].ToString();
                        pm.middlename.Text = read["middlename"].ToString();
                        pm.address0.Text = read["address"].ToString();
                        pm.gender.Text = read["gender"].ToString();
                        pm.relation.Text = read["relation"].ToString();
                    }
                    break;
                }

                //else
                //{
                //    MessageBox.Show("FACE NOT FOUND ON '"+ type +"' LISTS");
                //}

            }

            read.Close();
            cons.Close();
        }

        public prisonerfacerecog()
        {
            InitializeComponent();

            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(System.AppDomain.CurrentDomain.BaseDirectory + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load");
            }
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            if(frame_active)
            {
                face_count.Content = "0";
                //label4.Text = "";
                NamePersons.Add("");

                //Get the current frame form capture device
                currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Convert it to Grayscale
                gray = currentFrame.Convert<Gray, Byte>();

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
              face,
              1.2,
              10,
              Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
              new System.Drawing.Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    t = t + 1;
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentFrame.Draw(f.rect, new Bgr(System.Drawing.Color.Red), 2);


                    if (trainingImages.ToArray().Length != 0)
                    {
                        //TermCriteria for face recognition with numbers of trained images like maxIteration
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                        //Eigen face recognizer
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                           trainingImages.ToArray(),
                           labels.ToArray(),
                           3000,
                           ref termCrit);

                        name = recognizer.Recognize(result);

                        //Draw the label for each face detected and recognized
                        currentFrame.Draw(name, ref font, new System.Drawing.Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(System.Drawing.Color.LightGreen));

                    }

                    NamePersons[t - 1] = name;
                    NamePersons.Add("");


                    //Set the number of faces detected on the scene
                    face_count.Content = facesDetected[0].Length.ToString();

                    /*
                    //Set the region of interest on the faces

                    gray.ROI = f.rect;
                    MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                       eye,
                       1.1,
                       10,
                       Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                       new Size(20, 20));
                    gray.ROI = Rectangle.Empty;

                    foreach (MCvAvgComp ey in eyesDetected[0])
                    {
                        Rectangle eyeRect = ey.rect;
                        eyeRect.Offset(f.rect.X, f.rect.Y);
                        currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                    }
                     */

                }
                t = 0;
                //Names concatenation of persons recognized
                for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
                {


                    names = names + NamePersons[nnn];
                    //+ ", "



                }
                //Show the faces procesed and recognized
                face_preview.Source = ImageSourceForBitmap(currentFrame.ToBitmap());
                face_persons.Text = names;
                names = "";


                //Clear the list(vector) of names
                NamePersons.Clear();

               
            }
        }


        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        public ImageSource ImageSourceForBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(handle);
            }
        }
    }
}
