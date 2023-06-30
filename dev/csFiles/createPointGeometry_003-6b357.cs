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
  private void RunScript(Surface S, int U, int V, ref object P, ref object N, ref object M, ref object G, ref object uv)
  {
    //Algorithms
  
    // Get domains
    Interval uDomain = S.Domain(0);
    double uStep = uDomain.Length / U;
    Interval vDomain = S.Domain(1);
    double vStep = vDomain.Length / V;

    // Generate output information coordinates
    List<Point3d> pts = new List<Point3d>();
    List<Vector3d> normals = new List<Vector3d>();
    List<Point2d> uvPts = new List<Point2d>();
    List<double> means = new List<double>();
    List<double> gaussians = new List<double>();
    for (int i = 0; i < U + 1; i++)
    {
      double u = uDomain.T0 + i * uStep;
      for (int j = 0; j < V + 1; j++)
      {
        double v = vDomain.T0 + j * vStep;

        // Get surface curvature values
        SurfaceCurvature sc = S.CurvatureAt(u, v);

        // Extract info from the SC object
        pts.Add(sc.Point);
        normals.Add(sc.Normal);
        uvPts.Add(sc.UVPoint);
        means.Add(sc.Mean);
        gaussians.Add(sc.Gaussian);
      }
    }

    // Outputs
    P = pts;
    N = normals;
    M = means;
    G = gaussians;
    uv = uvPts;
    
  }
  #endregion
  #region Additional

  #endregion
}