using MonoDevelop.Core;
using MonoDevelop.Projects;

namespace RDevelop.RBinding
{
	public class RProject: Project
	{
		public override string ProjectType
		{
			get { return "RProject" ; }
		}

		public override IConfiguration CreateConfiguration (string name)
		{
			return null;
		}
	}
}
