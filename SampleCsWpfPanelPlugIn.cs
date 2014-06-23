using System.ComponentModel;
using System.Windows;

namespace SampleCsWpfPanel
{
  ///<summary>
  /// Every RhinoCommon plug-in must have one and only one Rhino.PlugIns.PlugIn
  /// inherited class. DO NOT create instances of this class yourself. It is the
  /// responsibility of Rhino to create an instance of this class.
  ///</summary>
  public class SampleCsWpfPanelPlugIn : Rhino.PlugIns.PlugIn
  {
    public SampleCsWpfPanelPlugIn()
    {
      Instance = this;
    }

    ///<summary>Gets the only instance of the SampleCsWpfPanelPlugIn plug-in.</summary>
    public static SampleCsWpfPanelPlugIn Instance
    {
      get;
      private set;
    }

    // You can override methods here to change the plug-in behavior on
    // loading and shut down, add options pages to the Rhino _Option command
    // and mantain plug-in wide options in a document.

    /// <summary>
    /// Is called when the plug-in is being loaded.
    /// </summary>
    protected override Rhino.PlugIns.LoadReturnCode OnLoad(ref string errorMessage)
    {
      System.Type panel_type = typeof(SampleCsWpfPanelHost);
      Rhino.UI.Panels.RegisterPanel(this, panel_type, "Sample", SampleCsWpfPanel.Properties.Resources.Main);

      return Rhino.PlugIns.LoadReturnCode.Success;
    }
  }

  /// <summary>
  /// Rhino framework requires a System.Windows.Forms.IWin32Window derived object for a panel.
  /// </summary>
  [System.Runtime.InteropServices.Guid("C29BC573-2D37-4E84-8357-3830CD50BD21")]
  public class SampleCsWpfPanelHost : RhinoWindows.Controls.WpfElementHost
  {
    public SampleCsWpfPanelHost()
      : base(new SampleCsWpfPanelUserControl(), null) // No view model (for this example)
    {
    }
  }
}