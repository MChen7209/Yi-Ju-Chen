require "test/unit"
require './src/perfect_number_imperative'

class PerfectNumberFinderImperativeTest < Test::Unit::TestCase
  def testIsPerfectNumberWhenTrue
    num = 28
    expected = true
    assert(PerfectNumberFinderImperative.isPerfectNumber(num))
  end

  def testIsPerfectNumberWhenFalse
    num = 10
    assert(!PerfectNumberFinderImperative.isPerfectNumber(num))
  end

  def testPerfectNumIsOdd
    num = 5
    expected = false
    assert(!PerfectNumberFinderImperative.isPerfectNumber(num))
  end

  def testSumOfFactorsCorrect
    num = 6
    assert(PerfectNumberFinderImperative.sumOfFactors(num) == num)
  end

  def testSumOfFactorsFail
    num = 30
    assert(PerfectNumberFinderImperative.sumOfFactors(num) != num)
  end

  def testPerfectNumberFailWhenZero
    num = 0
    assert(!PerfectNumberFinderImperative.isPerfectNumber(num))
  end

  def testPerfectNumberFailWhenOne
    num = 1
    assert(!PerfectNumberFinderImperative.isPerfectNumber(num))
  end

  def testPerfectNumberFailWhenNegative
    num = -28
    assert(!PerfectNumberFinderImperative.isPerfectNumber(num))
  end
end