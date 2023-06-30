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
public abstract class Script_Instance_65ce4 : GH_ScriptInstance
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
  private void RunScript(double radius, double height, int turns, int stepsPerTurn, ref object A, ref object B)
  {
    //Algorithms
    //create a spiral staircase
    //check chatGPT for psuedocode
    // define the starting point and direction of the spiral
    Point3d startPoint = new Point3d(0, 0, 0);
    Vector3d startDirection = new Vector3d(1, 0, 0);

    // define the radius and height of each step
    //testing

    // define the number of turns and steps in the spiral


    // define the list of points and curves that will make up the staircase
    List<Point3d> points = new List<Point3d>();
    List<Curve> curves = new List<Curve>();

    // define the current position and direction of the spiral
    Point3d currentPos = startPoint;
    Vector3d currentDir = startDirection;

    // create the spiral staircase
    for (int i = 0; i < turns * stepsPerTurn; i++)
    {
      // add the current point to the list of points
      points.Add(currentPos);

      // create a line from the current point to the next point
      // in the spiral, and add it to the list of curves
      Point3d nextPos = currentPos + currentDir * height;
      curves.Add(new LineCurve(currentPos, nextPos));

      // update the current position and direction of the spiral
      currentPos = nextPos;
      currentDir.Rotate(Math.PI * 2 / stepsPerTurn, Vector3d.ZAxis);
    }

    // create a polyline from the points and add it to the document
    Polyline spiral = new Polyline(points);
    doc.Objects.AddPolyline(spiral);

    // create a surface from the curves and add it to the document
    Brep brep = Brep.CreateFromLoft(curves, Point3d.Unset, Point3d.Unset, LoftType.Normal, false)[0];
    doc.Objects.AddBrep(brep);

    //Output
    A = spiral;
    B = brep;







































  }
  #endregion
  #region Additional

  #endregion
}