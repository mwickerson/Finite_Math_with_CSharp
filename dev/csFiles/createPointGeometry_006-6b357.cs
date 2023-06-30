using System;
using System.Collections;
using System.Collections.Generic;

using Rhino;
using Rhino.Geometry;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;



/// <summary>
/// This class will be instantiated on demand by the Script component.
/// </summary>
public abstract class Script_Instance_6b357 : GH_ScriptInstance
{
  #region Utility functions
  /// <summary>Print a String to the [Out] Parameter of the Script component.</summary>
  /// <param name="text">String to print.</param>
  private void Print(string text) { /* Implementation hidden. */ }
  /// <summary>Print a formatted String to the [Out] Parameter of the Script component.</summary>
  /// <param name="format">String format.</param>
  /// <param name="args">Formatting parameters.</param>
  private void Print(string format, params object[] args) { /* Implementation hidden. */ }
  /// <summary>Print useful information about an object instance to the [Out] Parameter of the Script component. </summary>
  /// <param name="obj">Object instance to parse.</param>
  private void Reflect(object obj) { /* Implementation hidden. */ }
  /// <summary>Print the signatures of all the overloads of a specific method to the [Out] Parameter of the Script component. </summary>
  /// <param name="obj">Object instance to parse.</param>
  private void Reflect(object obj, string method_name) { /* Implementation hidden. */ }
  #endregion

  #region Members
  /// <summary>Gets the current Rhino document.</summary>
  private readonly RhinoDoc RhinoDocument;
  /// <summary>Gets the Grasshopper document that owns this script.</summary>
  private readonly GH_Document GrasshopperDocument;
  /// <summary>Gets the Grasshopper script component that owns this script.</summary>
  private readonly IGH_Component Component;
  /// <summary>
  /// Gets the current iteration count. The first call to RunScript() is associated with Iteration==0.
  /// Any subsequent call within the same solution will increment the Iteration count.
  /// </summary>
  private readonly int Iteration;
  #endregion
  /// <summary>
  /// This procedure contains the user code. Input parameters are provided as regular arguments,
  /// Output parameters as ref arguments. You don't have to assign output parameters,
  /// they will have a default value.
  /// </summary>
  #region Runscript
  private void RunScript(int xCount, int yCount, double baseRadius, double zExtrude, ref object A, ref object B, ref object C, ref object D, ref object E)
  {
    //Algorithms
    //create a point grid in rhino common that maps out a surface floor plan for the acropolis
    //create a list of points
    List<Point3d> pts = new List<Point3d>();
    //populate the list with points
    for (int i = 0; i < xCount; i++)
    {
      for (int j = 0; j < yCount; j++)
      {
        pts.Add(new Point3d(i, j, 0));
      }
    }
    
    //select the points that are best used for the outer contour of the acropolis and create circles at those points
    //create a list of points
    List<Point3d> pts2 = new List<Point3d>();
    //populate the list with points that are on the outer contour of the acropolis
    for (int i = 0; i < xCount; i++)
    {
      for (int j = 0; j < yCount; j++)
      {
        if (i == 0 || i == xCount - 1 || j == 0 || j == yCount -1)
        {
          pts2.Add(new Point3d(i, j, 0));
        }
      }
    }
    //create a list of circles
    List<Circle> circles = new List<Circle>();
    //populate the list with circles at the points that are on the outer contour of the acropolis
    for (int i = 0; i < pts2.Count; i++)
    {
      circles.Add(new Circle(pts2[i], baseRadius));
    }
    //create a list of curves
    List<Curve> curves = new List<Curve>();
    //populate the list with curves that are the circles
    for (int i = 0; i < circles.Count; i++)
    {
      curves.Add(circles[i].ToNurbsCurve());
    }
    //create a list of surfaces using rhino common api
    List<Surface> surfaces = new List<Surface>();
    //populate the list with surfaces that are the extrusions of the curves
    for (int i = 0; i < curves.Count; i++)
    {
      surfaces.Add(Surface.CreateExtrusion(curves[i], new Vector3d(0, 0, zExtrude)));
    }
    
    // Outputs
    A = pts;
    B = pts2;
    C = circles;
    D = curves;
    E = surfaces;







  }
  #endregion
  #region Additional

  #endregion
}