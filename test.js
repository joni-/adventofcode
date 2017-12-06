const test = (fn, input, expected) => {
  const result = fn(input);

  if (result !== expected) {
    console.log(`Input "${input}": expected "${expected}", got "${result}"`);
  }
};

module.exports = test;
