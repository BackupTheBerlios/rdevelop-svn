using System.IO;
using MonoDevelop.Projects;
using MonoDevelop.Projects.Parser;
using MonoDevelop.Projects.CodeGeneration;

namespace RDevelop.RBinding
{
	public class RLanguageBinding: ILanguageBinding
	{
		public const string LanguageName = "R" ;

		public string Language
		{
			get { return LanguageName ; }
		}
		
		public string CommentTag
		{
			get { return "#" ; }
		}
		
		public bool IsSourceCodeFile (string fileName)
		{
			return Path.GetExtension(fileName).ToUpper() == ".R" ;
		}
		
		public IParser Parser
		{
			get { return null ; }
		}
		
		public IRefactorer Refactorer
		{
			get { return null ; }
		}
		
		public string GetFileName (string baseName)
		{
			return baseName + ".R" ;
		}
	}
}
