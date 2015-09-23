package fibonacciseries

class FibonacciSeries {
  def getSeriesRecursive(n: Int) : List[Int] = {
    n match {
      case 0 => List(1)
      case 1 => List(1, 1)
      case _ => {
        val previous = getSeriesRecursive(n - 1)
        previous :+ previous.takeRight(2).sum
      }
    }
  }
  
  def getSeriesTailRecursive(n : Int, current : Int=0, sequence : List[Int]=List(1)) : List[Int] = {
    n match {
      case 0 => sequence
      case _ => {
          getSeriesTailRecursive(n-1, sequence.last, sequence ::: List(current + sequence.last))
      }
    }
  }
}
