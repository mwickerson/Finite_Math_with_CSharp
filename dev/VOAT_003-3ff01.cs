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
public abstract class Script_Instance_3ff01 : GH_ScriptInstance
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
  private void RunScript(double x, double t, ref object A, ref object B, ref object C, ref object D)
  {
    //Algorithms
    //Euclidean Geometry, Similarity, Transformations
    //Deductive Geometry
    //write an algothim that demonstrates the VOAT Verticly Opposite Angles Theorem
    //create a XZ plane
    Plane plane = new Plane(new Point3d(0, 0, 0), new Vector3d(1, 0, 0));
    //create a circle on the plane
    Circle circle = new Circle(plane, x);

    //locate a point at the center of the circle
    Point3d center = circle.Center;
    //locate a point on the circle at 45 degrees
    Point3d point45 = circle.PointAt(Math.PI / 4);
    //locate a point on the circle at 225 degrees
    Point3d point225 = circle.PointAt(5 * Math.PI / 4);
    
    //create a line from center to point45
    Line line45 = new Line(center, point45);
    //create a line from center to point225
    Line line225 = new Line(center, point225);

    //create a random point on the circle at point t in radians
    Point3d randomPoint = circle.PointAt(t);
    //create a point on the circle at t + 180 degrees
    Point3d randomPoint180 = circle.PointAt(t + Math.PI);
    //create a line from randomPoint to randomPoint180
    Line randomLine = new Line(randomPoint, randomPoint180);



    // Outputs
    A = circle;
    B = line45;
    C = line225;
    D = randomLine;
    
































  }
  #endregion
  #region Additional

  #endregion
}