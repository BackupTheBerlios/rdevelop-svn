using System.Xml;
using MonoDevelop.Projects;

namespace RDevelop.RBinding
{
	public class RProjectBinding: IProjectBinding
	{
		public string Name
		{
			get { return "RProject" ; }
		}
		
		public Project CreateProject (ProjectCreateInformation info, XmlElement projectOptions)
		{
			RProject project = new RProject ();
			project.Name = info.ProjectName ;
			return project ;
		}
		
		public Project CreateSingleFileProject (string sourceFile)
		{
			RProject project = new RProject();
			project.Name = System.IO.Path.GetFileNameWithoutExtension(sourceFile);
			return project;
		}
		
		public bool CanCreateSingleFileProject (string sourceFile)
		{
			return true;
		}
	}
}
