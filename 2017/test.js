const test = (fn, input, expected) => {
  const result = fn(input);

  if (JSON.stringify(result) !== JSON.stringify(expected)) {
    console.log(`Input "${input}": expected "${expected}", got "${result}"`);
  }
};

module.exports = test;
