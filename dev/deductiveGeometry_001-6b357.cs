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
  private void RunScript(double x, double y, double z, double t, ref object A, ref object B, ref object C, ref object D)
  {
    //Algorithms
    //Euclidean Geometry, Similarity, Transformations
    //Deductive Geometry
    //write an algothim that demonstrates the CAT complementarity angle theorem 
    //create origin point
    Point3d origin = new Point3d(0, 0, 0);
    //create point at x,y,z
    Point3d point = new Point3d(x, y, 0);
    //create point at x,y,0
    Point3d point2 = new Point3d(0, 0, z);

    //create line from origin to point
    Line line = new Line(origin, point);
    //create line from origin to point2
    Line line2 = new Line(origin, point2);

    //create a line from point to point2
    Line line3 = new Line(point, point2);

    //find a point on line3 at the parameter value of t 
    Point3d point3 = line3.PointAt(t);

    //create a line from point to point3
    Line line4 = new Line(origin, point3);

    //calculate the angle between line and line4
    double angle = Vector3d.VectorAngle(line.Direction, line4.Direction);
    //convert angle to degrees
    double angleDeg = RhinoMath.ToDegrees(angle);
    //calculate the angle between line4 and line2
    double angle2 = Vector3d.VectorAngle(line4.Direction, line2.Direction);
    //convert angle to degrees
    double angleDeg2 = RhinoMath.ToDegrees(angle2);

    Print("The angle between line3 and line4 is " + angleDeg);
    Print("The angle between line3 and line2 is " + angleDeg2);

    if (angleDeg + angleDeg2 == 90)
    {
      Print("The angle add to 90 degrees");
    }
    else
    {
      Print("The angle do not add 90 degrees");
    }

    // Outputs
    A = line;
    B = line2;
    C = line3;
    D = line4;
    




    
    
    

    
    


    













  }
  #endregion
  #region Additional

  #endregion
}