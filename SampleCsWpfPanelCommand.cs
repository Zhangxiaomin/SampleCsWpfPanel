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
      System.Guid panelId = SampleCsWpfPanelHost.PanelId;
      bool bVisible = Rhino.UI.Panels.IsPanelVisible(panelId);

      string prompt = (bVisible)
        ? "Sample panel is visible. New value"
        : "Sample Manager panel is hidden. New value";

      Rhino.Input.Custom.GetOption go = new Rhino.Input.Custom.GetOption();
      int hide_index = go.AddOption("Hide");
      int show_index = go.AddOption("Show");
      int toggle_index = go.AddOption("Toggle");

      go.Get();
      if (go.CommandResult() != Rhino.Commands.Result.Success)
        return go.CommandResult();

      Rhino.Input.Custom.CommandLineOption option = go.Option();
      if (null == option)
        return Rhino.Commands.Result.Failure;

      int index = option.Index;

      if (index == hide_index)
      {
        if (bVisible)
          Rhino.UI.Panels.ClosePanel(panelId);
      }
      else if (index == show_index)
      {
        if (!bVisible)
          Rhino.UI.Panels.OpenPanel(panelId);
      }
      else if (index == toggle_index)
      {
        if (bVisible)
          Rhino.UI.Panels.ClosePanel(panelId);
        else
          Rhino.UI.Panels.OpenPanel(panelId);
      }
      return Result.Success;
    }
  }
}
