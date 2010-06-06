module TestClassTree
open System.Text

type Node (name : string, ply : int) =
     let _name = name
     let  _ply = ply
     
     let mutable _children : Node list = []
     let mutable _testMethods : string list = []
     
     member x.Name with get() = _name
     member x.Ply with get() = _ply
     member x.Children with get() = _children
     member x.TestMethods with get() = _testMethods
     
     member x.addTestMethod (testName : string) =  _testMethods <- _testMethods @ [testName]
        
     member x.getNodeNamed(nodeName : string) = x.addToChildrenIfNotFoundAndReturnReference nodeName
     
     member private x.hasNodeWith(nameToFind :string) : Option<Node> =
        let rec foundIn (nodes : Node list) = 
            match nodes with
            | x::xs when (x.Name = nameToFind) -> Some(x)
            | x::xs                            -> foundIn xs
            | []                               -> None
        
        foundIn _children
        
     member private x.addNode(child : Node) = 
        _children <- _children @ [child]
        child
     
     member private x.addToChildrenIfNotFoundAndReturnReference(name : string) =
        let existingNode = x.hasNodeWith name
        match existingNode with
        | None         -> x.addNode(new Node(name, _ply + 1))
        | _            -> existingNode.Value
     
     
     override x.ToString() = 
        let indent =
            let rec getIndentFor = function
                | 0   -> ""
                | ply -> "   " + getIndentFor (ply - 1)
            getIndentFor _ply    
            
        let sb = new StringBuilder()
        sb.AppendLine(indent + "* " + x.Name) |> ignore
        
        for testMethod in x.TestMethods do 
            sb.AppendLine(indent + "  » " + testMethod) |> ignore
        
        for childNode in x.Children do
            sb.AppendLine(childNode.ToString()) |> ignore
        
        sb.ToString()
    
    
    


  
