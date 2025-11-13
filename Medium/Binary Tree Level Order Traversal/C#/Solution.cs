using System;

namespace Binary_Tree_Level_Order_Traversal;

public class Solution {
	public IList<IList<int>> LevelOrder(TreeNode? root) {
		if (root == null) return [];

		List<IList<int>> levels = [[]];
		var nodes = new Queue<TreeNode>();
		nodes.Enqueue(root);

		while (true) {
			int level = nodes.Count;
			for (int i = 0; i < level; i++) {
				var node = nodes.Dequeue();
				levels[^1].Add(node.val);

				if (node.left != null)
					nodes.Enqueue(node.left);
				if (node.right != null)
					nodes.Enqueue(node.right);
			}

			if (nodes.Count > 0)
				levels.Add([]);
			else break;
		}

		return levels;	
	}
}

public class TreeNode {
	public int val;
	public int spacing;
	public TreeNode? left;
	public TreeNode? right;
	private readonly string id = Guid.NewGuid().ToString();

	public TreeNode(int?[] input) {
		val = 0;
		left = null;
		right = null;
		spacing = 1;
		Add(input);
	}

	public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null) {
		this.val = val;
		this.left = left;
		this.right = right;
		spacing = 1;
	}
	private void Add(int?[] input) {
		Queue<int?> nodes = new(input);
		if (!nodes.TryDequeue(out int? root) || root == null) 
			return;

		val = (int)root;
		Queue<TreeNode> level = new([this]);

		while (nodes.Count > 0) {
			var curr = level.Dequeue();
			
			int? l = nodes.Dequeue();
			if (l != null) {
				curr.left = new((int)l);
				level.Enqueue(curr.left);
			}

			if (nodes.TryDequeue(out int? r) && r != null) {
				curr.right = new((int)r);
				level.Enqueue(curr.right);
			}
		}
	}

	private static bool IsEndTree(List<List<string>> levels, int maxLevel) {
		if (levels.Count > 0) {
			var lastLevel = levels[^1];
			int maxWidth = (int)Math.Pow(2, maxLevel - 1);

			if (lastLevel.TrueForAll(s => s == " ") && lastLevel.Count >= maxWidth) {
				levels.RemoveAt(levels.Count - 1);
				return true;
			}
		}

		return false;
	}

	private string Print(List<List<string>> levels, int maxLevel) {
		System.Text.StringBuilder output = new();
		int maxWidth = (int)Math.Pow(2, maxLevel);

		for (int i = 0; i < levels.Count; i++) {
			int spaces = maxWidth / (int)Math.Pow(2, i + 1);
			output.Append(new string(' ', spaces));
			
			for (int j = 0; j < levels[i].Count; j++) {
				output.Append(levels[i][j]);
				output.Append(new string(' ', Math.Max(spaces * 2 - spacing, 0)));
			}
			output.AppendLine();
		}

		return output.ToString();
	}

	public override string ToString() {
		var levels = new List<List<string>>();
		var queue = new Queue<(TreeNode? node, int level)>();
		var seen = new HashSet<string>();
		queue.Enqueue((this, 0));
		
		int maxLevel = 0;
		while (queue.Count > 0) {
			var (node, level) = queue.Dequeue();

			if (levels.Count <= level)
				levels.Add([]);

			if (node == null || !seen.Add(node.id)) {
				levels[level].Add(" ");
				queue.Enqueue((null, level + 1));
				queue.Enqueue((null, level + 1));
			}
			else {
				levels[level].Add(node.val.ToString());
				queue.Enqueue((node.left, level + 1));
				queue.Enqueue((node.right, level + 1));
			}

			maxLevel = Math.Max(maxLevel, level + 1);
			if (IsEndTree(levels, maxLevel)) break;
		}

		return Print(levels, maxLevel);
	}
}
