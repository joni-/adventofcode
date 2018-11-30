const findCoordinate = (needle, target) => {

}


const solve = (input) => {
  const accessPortCoordinate = findCoordinate(1, input);
  const inputCoordinate = findCoordinate(input, input);

  const diffRow = Math.abs(accessPortCoordinate.row - inputCoordinate.row)
  const diffCol = Math.abs(accessPortCoordinate.col - inputCoordinate.col)

  return diffRow + diffCol;
};

const test = (input, expected) => {
  const result = solve(input);

  if (result !== expected) {
    console.log(`Input "${input}": expected "${expected}", got "${result}"`);
  }
};

test(1, 0);
test(12, 3);
test(23, 2);
test(1024, 31);
