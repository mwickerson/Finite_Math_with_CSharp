using System;
using System.Collections;
using System.Collections.Generic;

using Rhino;
using Rhino.Geometry;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

using System.IO;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using Rhino.DocObjects;
using Rhino.Collections;
using GH_IO;
using GH_IO.Serialization;


/// <summary>
/// This class will be instantiated on demand by the Script component.
/// </summary>
public abstract class Script_Instance_fbe55 : GH_ScriptInstance
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
  private void RunScript(double xa, double ya, double xb, double yb, double xc, double yc, ref object polylineOut, ref object midPtsOut, ref object A, ref object B, ref object C, ref object D, ref object E)
  {
    //create a pentagon centered on the origin with a radius of 1
    Point3d[] pts = new Point3d[5];
    pts[0] = new Point3d(xa, ya, 0);
    pts[1] = new Point3d(xb, yb, 0);
    pts[2] = new Point3d(xc, -yc, 0);
    pts[3] = new Point3d(-xc, -yc, 0);
    pts[4] = new Point3d(-xb, yc, 0);

    //create a polygon
    Polyline pl = new Polyline(pts);
    pl.Add(pts[0]);

    //find the midpoint of the polyline segments
    List<Point3d> midPts = new List<Point3d>();
    for (int i = 0; i < pl.Count - 1; i++)
    {
      Point3d midPt = pl[i] + (pl[i + 1] - pl[i]) / 2;
      midPts.Add(midPt);
    }
    //find the center of the points
    Point3d centroid = Point3d.Origin;
    
    //move the midPts halfway to the centroid
    for (int i = 0; i < midPts.Count; i++)
    {
      midPts[i] = midPts[i] + (centroid - midPts[i]) / 2;
    }
    //move the midPts up by 1
    for (int i = 0; i < midPts.Count; i++)
    {
      midPts[i] = midPts[i] + new Vector3d(0, 0, 1);
    }
    //create a list of line that connect the midPts to the original points
    List<Line> lines = new List<Line>();
    for (int i = 0; i < midPts.Count; i++)
    {
      Line l = new Line(midPts[i], pl[i]);
      lines.Add(l);
    }
    //create a list of points that are the intersection of the lines

    //Outputs
    polylineOut = pl;
    midPtsOut = midPts;
    A = lines[0];
    B = lines[1];
    C = lines[2];
    D = lines[3];
    E = lines[4];
  


  }
  #endregion
  #region Additional

  #endregion
}