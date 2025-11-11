using System;

namespace Subtree_of_Another_Tree;

public class Solution {
	public bool IsSubtree(TreeNode? root, TreeNode subRoot) {
		if (root == null) return false;

		if (root.val == subRoot.val && IsSameTree(root, subRoot)) {
			return true;
		}

		return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
	}
	
	public bool IsSameTree(TreeNode? t1, TreeNode? t2) {
		if (t1 == null && t2 == null) return true;
		if (t1 == null || t2 == null || t1.val != t2.val) return false;

		return IsSameTree(t1.left, t2.left) && IsSameTree(t1.right, t2.right);
	}
}

public class TreeNode {
	public int val;
	public TreeNode? left;
	public TreeNode? right;
	private TreeNode? curr = null;
	private readonly string id = Guid.NewGuid().ToString();

	public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null) {
		this.val = val;
		this.left = left;
		this.right = right;
	}

	public TreeNode AddLeft(int value) {
		curr ??= this;
		curr.left = new TreeNode(value);
		curr = curr.left;
		return this;
	}

	public TreeNode AddRight(int value) {
		curr ??= this;
		curr.right = new TreeNode(value);
		curr = curr.right;
		return this;
	}

	public TreeNode AddLeft(TreeNode node) {
		curr ??= this;
		curr.left = node;
		curr = curr.left;
		return this;
	}

	public TreeNode AddRight(TreeNode node) {
		curr ??= this;
		curr.right = node;
		curr = curr.right;
		return this;
	}

	public override string ToString() {
		var output = new List<int>();
		var visited = new HashSet<string>();
		var stack = new Stack<TreeNode>();
		stack.Push(this);

		while (stack.Count > 0) {
			var node = stack.Pop();
			if (node == null || !visited.Add(node.id))
				continue;

			output.Add(node.val);

			if (node.right != null)
				stack.Push(node.right);
			if (node.left != null)
				stack.Push(node.left);
		}

		return string.Join(", ", output);
	}
}
