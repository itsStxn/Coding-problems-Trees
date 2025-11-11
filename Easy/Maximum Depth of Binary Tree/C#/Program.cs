using Maximum_Depth_of_Binary_Tree;

var task = new Solution();
var root = new TreeNode(3, new(9), new(20, new(15), new(7)));
var result = task.MaxDepth(root);
Console.WriteLine(result);
