const test = require('./test');

const maxIndex = (list) => list.reduce(
  (acc, current, index) =>
    current > acc.val ? { val: current, index: index } : acc,
  { val: Number.MIN_SAFE_INTEGER, index: -1 }
).index;

const redistributeBlock = (memoryBank, blocks, start) => {
  let newBank = [...memoryBank];

  for (let i = 0; i < blocks; i++) {
    const index = (i + start) % newBank.length;
    newBank[index] += 1;
  }

  return newBank;
};

const redistribute = (memoryBank) => {
  const cell = maxIndex(memoryBank);
  const blocks = memoryBank[cell];

  const withoutMaxBlock = [
    ...memoryBank.slice(0, cell),
    0,
    ...memoryBank.slice(cell + 1)
  ];

  return redistributeBlock(withoutMaxBlock, blocks, (cell + 1) % memoryBank.length);
}

const solve = (input) => {
  let reallocated = redistribute(input);
  const visited = new Set([JSON.stringify(reallocated)]);

  while (true) {
    reallocated = redistribute(reallocated);
    const asString = JSON.stringify(reallocated);

    if (visited.has(asString)) {
      break;
    }

    visited.add(asString);
  }

  return visited.size + 1;
};

test(redistribute, [0, 2, 7, 0], [2, 4, 1, 2]);
test(redistribute, [2, 4, 1, 2], [3, 1, 2, 3]);
test(redistribute, [3, 1, 2, 3], [0, 2, 3, 4]);
test(redistribute, [0, 2, 3, 4], [1, 3, 4, 1]);
test(redistribute, [1, 3, 4, 1], [2, 4, 1, 2]);

test(solve, [0, 2, 7, 0], 5);

const input = '4 10 4 1 8 4 9 14 5 1 14 15 0 15 3 5'.split(' ').map(Number);
test(solve, input, 12841);
console.log(solve(input));

