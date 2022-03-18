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
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : UserControl
    {
        Projects projectsObj;
        Project projectToBeEdited;

        public EditPage(Projects projectsArg, string? IDToBeEditedArg)
        {
            InitializeComponent();

            projectsObj = projectsArg;
            projectToBeEdited = projectsObj.projects.Find(x => x.id == IDToBeEditedArg);
            DataContext = projectToBeEdited;
        }

        private void EditProjectClick(object sender, RoutedEventArgs e)
        {
            if (projectToBeEdited != null)
            {
                projectToBeEdited.Name = NameInput.Text.ToString();
                projectToBeEdited.Abbreviation = AbbreviationInput.Text.ToString();
                projectToBeEdited.Customer = CustomerInput.Text.ToString();
            }

            Content = new ProjectsPage(projectsObj);
        }

        private void CancelEditClick(object sender, RoutedEventArgs e)
        {
            Content = new ProjectsPage(projectsObj);
        }
    }
}