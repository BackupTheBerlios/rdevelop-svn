// $Id$
//
// Copyright © 2006 Sébastien Nicouleaud
//
// This file is part of RDevelop.RConsole.
// 
// RDevelop.RConsole is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// RDevelop.RConsole is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with RDevelop.RConsole; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide.Gui;
using MonoDevelop.SourceEditor.Gui;
using RDevelop.RConsole;

namespace RDevelop.RConsole.Commands
{
	public enum Commands
	{
		//RunFileInRConsole,
		RunSelectionInRConsole
	}
	
	internal class RunSelectionInRConsoleHandler: CommandHandler
	{
		protected override void Run()
		{
			Document activeDocument = IdeApp.Workbench.ActiveDocument;
			if (activeDocument != null && activeDocument.Content is SourceEditorDisplayBindingWrapper)
			{
				string selectedText = ((SourceEditor) ((SourceEditorDisplayBindingWrapper)activeDocument.Content).Editor).Buffer.GetSelectedText();
				if (selectedText != null && selectedText.Length > 0)
				{
					Console.WriteLine(selectedText);
					RConsolePad rConsolePad = RConsolePad.Instance;
					Pad pad = IdeApp.Workbench.ShowPad (rConsolePad);
					pad.BringToFront();
					//rConsolePad.BringToFront();
					rConsolePad.Terminal.FeedChild(selectedText + "\n");
				}
			}
		}
		
		protected override void Update(CommandInfo info)
		{
			Document activeDocument = IdeApp.Workbench.ActiveDocument;
			if (activeDocument != null && activeDocument.Content is SourceEditorDisplayBindingWrapper)
			{
				string selectedText = ((SourceEditor) ((SourceEditorDisplayBindingWrapper)activeDocument.Content).Editor).Buffer.GetSelectedText();
				info.Enabled = (selectedText != null && selectedText.Length > 0);
			}
		}
	}
}
