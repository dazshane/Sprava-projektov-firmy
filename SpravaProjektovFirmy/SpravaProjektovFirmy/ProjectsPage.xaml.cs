using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace SpravaProjektovFirmy
{
    /// <summary>
    /// Interaction logic for ProjectsPage.xaml
    /// </summary>
    public partial class ProjectsPage : UserControl
    {
        public Projects projectsObj;

        public ProjectsPage(Projects projectsComebackArg)
        {
            InitializeComponent();

            if (projectsComebackArg != null)
            {
                projectsObj = projectsComebackArg;
                SaveProjects();
            }

            LoadProjects();
        }

        public void LoadProjects()
        {
            string path = "C:/Users/Marek/source/repos/Sprava-projektov-firmy/SpravaProjektovFirmy/SpravaProjektovFirmy/projects.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Projects));

            using (StreamReader reader = new StreamReader(path))
            {
                projectsObj = (Projects)serializer.Deserialize(reader) ?? throw new ArgumentException();
            }

            DataContext = projectsObj.projects;
        }

        public void SaveProjects()
        {
            string path = "C:/Users/Marek/source/repos/Sprava-projektov-firmy/SpravaProjektovFirmy/SpravaProjektovFirmy/projects.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Projects));

            TextWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, projectsObj);
            writer.Close();
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            Content = new LoginPage();
        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {
            Content = new CreatePage(projectsObj);
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            var IDToBeEdited = ((Button)sender).Tag;
            Content = new EditPage(projectsObj, IDToBeEdited.ToString());
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            var IDToBeDeleted = ((Button)sender).Tag;
            Delete(IDToBeDeleted.ToString());
            LoadProjects();
        }

        public void Delete(string IDToBeDeleted)
        {
            LoadProjects();
            projectsObj.projects.Remove(projectsObj.projects.Find(x => x.id == IDToBeDeleted));
            SaveProjects();
        }
    }
}