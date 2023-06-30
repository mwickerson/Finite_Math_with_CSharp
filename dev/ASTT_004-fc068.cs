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
public abstract class Script_Instance_fc068 : GH_ScriptInstance
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
  private void RunScript(double x, double u, double v, double w, ref object A, ref object B, ref object C, ref object D)
  {
    //Algorithms
    //Euclidean Geometry, Similarity, Transformations
    //Deductive Geometry
    //write an algothim that demonstrates the Angle Sum Triangle Theorem
    //create a XZ plane
    Plane plane = new Plane(new Point3d(0, 0, 0), new Vector3d(0, 0, 1));
    //create a circle on the plane
    Circle circle = new Circle(plane, x);

    //create three points on the circle at point u,v, and w
    Point3d pt1 = circle.PointAt(u);
    Point3d pt2 = circle.PointAt(v);
    Point3d pt3 = circle.PointAt(w);

    //create a line from pt1 to pt2
    Line line1 = new Line(pt1, pt2);
    //create a line from pt2 to pt3
    Line line2 = new Line(pt2, pt3);
    //create a line from pt3 to pt1
    Line line3 = new Line(pt3, pt1);

    // Outputs
    A = circle;
    B = line1;
    C = line2;
    D = line3;


































  }
  #endregion
  #region Additional

  #endregion
}