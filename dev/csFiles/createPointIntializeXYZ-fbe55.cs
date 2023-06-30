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
  private void RunScript(double x, double y, double z, ref object Point, ref object lineOut, ref object movedLineOut, ref object A, ref object B, ref object C)
  {
    //Create an instance of a point and initialize to x, y and z
    Point3d pt = new Point3d(x, y, z);
    //Create a line from the origin to the point
    Line line = new Line(Point3d.Origin, pt);
    //move the line 10 units in the x direction
    Line movedLine = new Line(line.From + new Vector3d(10, 0, 0), line.To + new Vector3d(10, 0, 0));
    //move the line 10 times in a range that uses trigonometry to create a list of 10 new lines
    List<Line> trigLines = new List<Line>();
    for (int i = 0; i < 10; i++)
    {
      double angle = i * 2 * Math.PI / 10;
      double xMove = Math.Cos(angle) * 10;
      double yMove = Math.Sin(angle) * 10;
      Line trigLine = new Line(line.From + new Vector3d(xMove, yMove, 0), line.To + new Vector3d(xMove, yMove, 0));
      trigLines.Add(trigLine);
    }
  
    //transform the list of lines with rotating transformations
    List<Line> trigLinesRotated = new List<Line>();
    for (int i = 0; i < 10; i++)
    {
      double angle = i * 2 * Math.PI / 10;
      Transform xform = Transform.Rotation(angle, Vector3d.ZAxis, Point3d.Origin);
      Line trigLineRotated = trigLines[i];
      trigLineRotated.Transform(xform);
      trigLinesRotated.Add(trigLineRotated);
    }
    //make a copy of the trigLinesRotated and mirror the trigLinesRotated on the xy plane
    List<Line> trigLinesRotatedMirrored = new List<Line>();
    for (int i = 0; i < 10; i++)
    {
      Line trigLineRotatedMirrored = trigLinesRotated[i];
      trigLineRotatedMirrored.Transform(Transform.Mirror(Plane.WorldXY));
      trigLinesRotatedMirrored.Add(trigLineRotatedMirrored);
    }
    //Orient trigLinesRotatedMirrored to a parametrically controlled rectangle grid on the yz plane
    List<Line> trigLinesRotatedMirroredOriented = new List<Line>();
    for (int i = 0; i < 10; i++)
    {
      double xMove = i * 10;
      double yMove = i * 10;
      Line trigLineRotatedMirroredOriented = trigLinesRotatedMirrored[i];
      trigLineRotatedMirroredOriented.Transform(Transform.Translation(xMove, yMove, 0));
      trigLinesRotatedMirroredOriented.Add(trigLineRotatedMirroredOriented);
    }
    
    

    //output
    Point = pt;
    lineOut = line;
    movedLineOut = trigLines;
    A = trigLinesRotated;
    B = trigLinesRotatedMirrored;
    C = trigLinesRotatedMirroredOriented;
  

  }
  #endregion
  #region Additional

  #endregion
}