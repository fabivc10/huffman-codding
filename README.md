# Huffman Coding

A C# implementation of the **Huffman Coding algorithm**, a lossless compression technique that assigns variable-length binary codes to characters based on their frequency.

## How It Works

Huffman Coding follows three main steps:

1. **Frequency Analysis:** Count how frequently each character appears.
2. **Tree Construction:** Repeatedly select the two nodes with the lowest frequencies, combine them into a parent node, and insert the parent back into the collection. Continue until only one node (the root) remains.
3. **Code Generation:** Traverse the binary tree using DFS. Assign `0` when moving left and `1` when moving right. Each character's code is the path from the root to its leaf.

Frequently occurring characters receive shorter codes, while less frequent characters receive longer codes.

## Data Structure

The algorithm uses a binary tree composed of two types of nodes:

- **Leaf nodes:** Represent individual characters and their frequencies.
- **Internal nodes:** Represent the combination of two nodes. Their frequency is the sum of their children's frequencies.

## Implementation

The implementation consists of four main methods:

| Method | Responsibility |
|---|---|
| `GetAppeacesList()` | Groups characters and calculates their frequencies using LINQ. |
| `GenerateTree()` | Recursively combines the two nodes with the lowest frequencies to construct the Huffman tree. |
| `GetSolution()` | Traverses the tree using DFS to generate binary codes. |
| `Run()` | Coordinates frequency analysis, tree construction, and code generation. |

## Example

**Input:**
```text
mississippi
```

**Character frequencies:**

| Character | Frequency |
|---|---:|
| i | 4 |
| s | 4 |
| p | 2 |
| m | 1 |

One possible set of Huffman codes is:

| Character | Binary Code |
|---|---|
| i | 01 |
| s | 1 |
| p | 000 |
| m | 001 |

*Note: Different valid codes may result from different choices when frequencies are tied.*

## Complexity

Let `n` represent the number of distinct characters.

- Frequency analysis: O(L), where L is the input length.
- Tree construction: O(n²) with the current list-based approach.
- Code generation: O(n).

A priority queue can optimize tree construction to O(n log n).

## Future Improvements

- Replace the list-based minimum search with `.NET PriorityQueue`.
- Implement binary encoding and decoding.
- Handle edge cases, including empty input and single-character input.
- Add unit tests to validate tree construction and encoding correctness.

## References

- [Huffman Coding – Wikipedia](https://en.wikipedia.org/wiki/Huffman_coding)
