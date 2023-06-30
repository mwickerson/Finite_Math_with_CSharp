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
  private void RunScript(double x, double y, double z, ref object A, ref object B, ref object C, ref object D, ref object E, ref object F, ref object G, ref object H, ref object I)
  {
    //Algorithms
    //Euclidean Geometry, Similarity, Transformations
    //write an algothim that demonstrates the PLT parallel lines theorem
    //given a line and a point, find the line that is parallel to the given line and passes through the given point
    Line line = new Line(new Point3d(0, 0, 0), new Point3d(x, y, z));
    Point3d point = new Point3d(x, y, 0);
    Line line2 = new Line(point, line.Direction);

    //write and algothim that demonstrates the ITT Isoceles Triangle Theorem
    //given two equal length lines starting at the same point, find the third line that connects ends of the two lines
    Line line3 = new Line(new Point3d(0, 0, 0), new Point3d(x, y, z));
    Line line4 = new Line(new Point3d(0, 0, 0), new Point3d(-x, -y, z));
    Line line5 = new Line(new Point3d(x, y, z), new Point3d(-x, -y, z));

    //write an algothim that demonstrates the VOAT Vertical Opposite Angles Theorem
    //create two intersecting lines, find the angle between the two lines
    Line line6 = new Line(new Point3d(-x, -y, -z), new Point3d(x, y, z));
    Line line7 = new Line(new Point3d(x, y, -z), new Point3d(-x, -y, z));
    //find the angle between the two lines in degrees
    double angle = Vector3d.VectorAngle(line6.Direction, line7.Direction) * 180 / Math.PI;
   
    // Outputs
    A = line;
    B = point;
    C = line2;
    D = line3;
    E = line4;
    F = line5;
    G = line6;
    H = line7;
    I = angle;
    



    
    
    

    
    


    













  }
  #endregion
  #region Additional

  #endregion
}