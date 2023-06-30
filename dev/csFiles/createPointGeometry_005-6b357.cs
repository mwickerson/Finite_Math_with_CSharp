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
  private void RunScript(Surface S, int U, int V, double r, ref object A, ref object vecOut, ref object randOut, ref object vecOut3, ref object B)
  {
    //Algorithms
    //create a list of points
    List<Point3d> pts = new List<Point3d>();
    //populate the list with points
    for (int i = 0; i < U; i++)
    {
      for (int j = 0; j < V; j++)
      {
        //create a point
        Point3d pt = S.PointAt((double) i / (U - 1), (double) j / (V - 1));
        //add the point to the list
        pts.Add(pt);
      }
    }
    //create a vector from the origin(x,y,z) to each of the points
    List<Vector3d> vector = new List<Vector3d>();
    for (int i = 0; i < pts.Count; i++)
    {
      Vector3d vec = new Vector3d(pts[i]);
      vector.Add(vec);
    }
    //applify the vector by a random number
    for (int i = 0; i < vector.Count; i++)
    {
      //create a random number generator
      Random rand2 = new Random();
      //create a random number
      //double r = rand2.NextDouble();
      //multiply the vector by the random number
      vector[i] = vector[i] * r;
    }

    //create a random walker algorithm that create 1000 points
    //create a list of points
    List<Point3d> pts2 = new List<Point3d>();
    //create a random number generator
    Random rand = new Random();
    //create a point
    Point3d pt2 = new Point3d(0, 0, 0);
    //add the point to the list
    pts2.Add(pt2);
    //create a loop that will create 1000 points
    for (int i = 0; i < 100; i++)
    {
      //create a random number
      int r1 = rand.Next(0, vector.Count);
      //create a vector
      Vector3d vec2 = vector[r1];
      //create a point
      Point3d pt3 = new Point3d(pt2 + vec2);
      //add the point to the list
      pts2.Add(pt3);
      //update the point
      pt2 = pt3;
    }

    //orient the points to the pts2 list
    //create a list of vectors
    List<Vector3d> vec3 = new List<Vector3d>();
    //create a loop that will create a vector from each point to the next point
    for (int i = 0; i < pts.Count; i++)
    {
      //create a vector
      Vector3d vec4 = new Vector3d(pts[i]);
      //add the vector to the list
      vec3.Add(vec4);
    }
    //create a loop that will orient the points
    for (int i = 0; i < pts.Count; i++)
    {
      //create a point
      Point3d pt4 = new Point3d(pts[i] + vec3[i]);
      //add the point to the list
      pts[i] = pt4;
    }

    // Outputs
    A = pts;
    vecOut = vector;
    randOut = pts2;
    vecOut3 = vec3;
    B = pts2;



    


  }
  #endregion
  #region Additional

  #endregion
}