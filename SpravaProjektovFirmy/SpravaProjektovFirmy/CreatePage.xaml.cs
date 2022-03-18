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
    /// Interaction logic for CreatePage.xaml
    /// </summary>
    public partial class CreatePage : UserControl
    {
        Projects projectsObj;

        public CreatePage(Projects projectsArg)
        {
            InitializeComponent();
            projectsObj = projectsArg;
        }

        private void CreateProjectClick(object sender, RoutedEventArgs e)
        {
            int newId = Int32.Parse(projectsObj.projects[projectsObj.projects.Count - 1].id.Remove(0, 3)) + 1;

            Project newProject = new()
            {
                id = "prj" + newId,
                Name = NameInput.Text.ToString(),
                Abbreviation = AbbreviationInput.Text.ToString(),
                Customer = CustomerInput.Text.ToString()
            };
            projectsObj.projects.Add(newProject);

            Content = new ProjectsPage(projectsObj);
        }

        private void CancelProjectClick(object sender, RoutedEventArgs e)
        {
            Content = new ProjectsPage(projectsObj);
        }
    }
}