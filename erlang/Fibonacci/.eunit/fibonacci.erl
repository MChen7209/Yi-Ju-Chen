-module(fibonacci).
-export([fibonacciRecursion/1, fibonacciTailRecursion/3]).

    fibonacciRecursion(0) -> [1];
    fibonacciRecursion(1) -> [1, 1];
    fibonacciRecursion(N) -> Sequence = fibonacciRecursion(N - 1), 
                             Sequence ++ [lists:nth(N - 1, Sequence) + lists:nth(N, Sequence)].
                             
    fibonacciTailRecursion(N, Current, Sequence) -> 
        case N of
            0 -> Sequence;
            _ -> fibonacciTailRecursion(N - 1, lists:last(Sequence), Sequence ++ [ Current + lists:last(Sequence)])
        end.