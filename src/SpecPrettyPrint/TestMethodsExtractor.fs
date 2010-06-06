#light

module TestMethodsExtractor

    open System
    open System.Reflection
    open System.Collections.Generic 
    
    open Prettyfier
    open TestClassTree
    
    type TestClassInfo = { Namespace : string; Hierarchy : string list }
    
    let getClassInfo (clazz : Type) = 
        let rec hierarchy (clazz : Type) =
            match clazz with
            | c when c = typeof<Object>      -> []
            | c                              -> hierarchy c.BaseType @ [c]
        
        let hierarchyNames (classes : Type list) =
            classes 
            |> List.map(function clazz -> clazz.Name)    
            
        { Namespace = clazz.Namespace;
          Hierarchy = clazz |> hierarchy |> hierarchyNames }
    
    type TestMethodInfo = { TestClass : TestClassInfo; MethodName : string; PrettyMethodName : string }
    
    let testMethodInfo (methodInfo : MethodInfo) =
        { TestClass = methodInfo.DeclaringType |> getClassInfo;
          MethodName = methodInfo.Name;
          PrettyMethodName = prettyfy methodInfo.Name }  
    
    
    let isTestMethod (methodInfo : MethodInfo) =
        let getCustomAttributes (methodInfo : MethodInfo) = methodInfo.GetCustomAttributes(false)
        
        let isTestMethodAttribute (attribute : obj) = 
            match attribute.GetType().Name with
            | "TestMethodAttribute" ->  true
            | _                     ->  false
        
        let testAttributes =
            methodInfo
            |> getCustomAttributes
            |> Array.filter (function (attrib:obj) -> attrib |> isTestMethodAttribute)
        
        testAttributes.Length > 0 
        
    let getAllTestMethodInfos (asm : Assembly) : TestMethodInfo[] =  
    
        let getAllPublicClasses = asm.GetExportedTypes()
        let getPublicMethodsIn (clazz : Type) = clazz.GetMethods()
       
        [for clazz : Type in getAllPublicClasses -> 
                getPublicMethodsIn clazz 
                |> Array.filter(isTestMethod)
                |> Array.map(testMethodInfo)]
        |> List.reduce(fun allMethods classMethods -> classMethods |> Array.append allMethods )
 
    let assemblyFor fullPath = 
        
        let loadAssembly fullPath = Reflection.Assembly.LoadFile fullPath
        
        loadAssembly fullPath;
   
    let getTestMethodTree (fullPath : string) =
     
        let asm = assemblyFor fullPath
        let rootNode = new Node(asm.FullName, 0)
        
        for met in getAllTestMethodInfos asm do
            let mutable lastNode : Node =  rootNode.getNodeNamed(met.TestClass.Namespace)
           
            for clazz in met.TestClass.Hierarchy do
                let newNode = lastNode.getNodeNamed(prettyfy clazz)
                lastNode <- newNode
            lastNode.addTestMethod(met.PrettyMethodName)    
         
        rootNode       



