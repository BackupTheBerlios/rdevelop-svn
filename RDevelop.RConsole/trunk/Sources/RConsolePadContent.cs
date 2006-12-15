// $Id$
//
// Copyright © Sébastien Nicouleaud 2006
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
using System.Collections;
using MonoDevelop.Ide.Gui;
using RDevelop.RConsole;
using Vte; // libvte2.0-cil
using Gtk;

namespace RDevelop.RConsole
{
	public class RConsolePad: AbstractPadContent
	{
		Widget widget;
		Terminal terminal;
		
		public RConsolePad(): base("R Console")
		{
			Frame frame = new Frame();
			ScrolledWindow scrolledWindow = new ScrolledWindow();
			HBox hbox = new HBox ();
			terminal = new Terminal();
			VScrollbar vscrollbar = new VScrollbar(terminal.Adjustment);
			hbox.PackStart(terminal, true, true, 0);
			hbox.PackStart(vscrollbar, false, true, 0);
			
			//scrolledWindow.AddWithViewport(hbox);
			frame.ShadowType = Gtk.ShadowType.In;
			scrolledWindow.Add(hbox);
			frame.Add(scrolledWindow);
			
			widget = frame;
			DefaultPlacement = "bottom";
			
			string[] environment = new string[Environment.GetEnvironmentVariables().Count];
			int index = 0;
			foreach (DictionaryEntry e in Environment.GetEnvironmentVariables ())
			{
				environment[index++] = String.Format ("{0}={1}", e.Key, e.Value);
			}
			terminal.ForkCommand(
				"R",
				new string[] {"--no-save"},
				environment,
				Environment.CurrentDirectory,
				false,
				false,
				false
			);
			
			frame.ShowAll();
			instance = this;
		}
		public Terminal Terminal { get { return terminal; } }
		public override Widget Control { get { return widget; } }
		static RConsolePad instance;
		public static RConsolePad Instance {
			get {
				if (instance != null)
					return instance;
				return new RConsolePad();
			}
		}
	}
}
