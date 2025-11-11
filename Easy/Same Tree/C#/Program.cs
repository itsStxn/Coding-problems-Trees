using Same_Tree;

var task = new Solution();
var tree1 = new TreeNode(1, new(2), new(3));
var tree2 = new TreeNode(1, new(2), new(3));
var result = task.IsSameTree(tree1, tree2);
Console.WriteLine(result);
