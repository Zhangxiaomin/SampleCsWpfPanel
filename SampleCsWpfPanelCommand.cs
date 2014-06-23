using System;
using System.Collections.Generic;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;

namespace SampleCsWpfPanel
{
  [System.Runtime.InteropServices.Guid("9c4f3dc1-4cda-4678-b5b4-050d87995f60")]
  public class SampleCsWpfPanelCommand : Command
  {
    /// <summary>
    /// Public constructor
    /// </summary>
    public SampleCsWpfPanelCommand()
    {
    }

    /// <summary>
    /// The command name as it appears on the Rhino command line.
    /// </summary>
    public override string EnglishName
    {
      get { return "SampleCsWpfPanelCommand"; }
    }

    /// <summary>
    /// Called by Rhino when the user wants to run this command.
    /// </summary>
    protected override Result RunCommand(RhinoDoc doc, RunMode mode)
    {
      return Result.Success;
    }
  }
}
