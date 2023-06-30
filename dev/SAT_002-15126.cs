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
public abstract class Script_Instance_15126 : GH_ScriptInstance
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
  private void RunScript(double x, double t, ref object A, ref object B, ref object C, ref object D, ref object E)
  {
    //Algorithms
    //Euclidean Geometry, Similarity, Transformations
    //Deductive Geometry
    //write an algothim that demonstrates the SAT Supplemantary Angle Theorem
    //create a XZ plane
    Plane plane = new Plane(new Point3d(0, 0, 0), new Vector3d(0, 1, 0));
    //create a circle on the plane
    Circle circle = new Circle(plane, x);

    //locate a point at the center of the circle
    Point3d center = circle.Center;
    //locate a point on the circle at 0 degrees
    Point3d point0 = circle.PointAt(0);
    //locate a point on the circle at 180 degrees
    Point3d point180 = circle.PointAt(Math.PI);
    //create a line from center to point0
    Line line0 = new Line(center, point0);
    //create a line from center to point180
    Line line180 = new Line(center, point180);

    //create a random point on the circle at point t
    Point3d pointT = circle.PointAt(t * Math.PI);
    //create a line from center to pointT
    Line lineT = new Line(center, pointT);
    //find angle between line0 and lineT
    double angle = Vector3d.VectorAngle(line0.Direction, lineT.Direction);
    //find angle between line180 and lineT
    double angle2 = Vector3d.VectorAngle(line180.Direction, lineT.Direction);
    //find the sum of the angles in degrees
    double sum = angle + angle2;


 
    // Outputs
    A = circle;
    B = line0;
    C = line180;
    D = sum;
    E = lineT;


    
    




    
    
    

    
    


    













  }
  #endregion
  #region Additional

  #endregion
}