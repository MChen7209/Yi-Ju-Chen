class PerfectNumberFinderFunctional
	def self.isPerfectNumber(num)
		num > 1 && sumOfFactors(num) == num
	end

	def self.sumOfFactors(num)
		(1...num).find_all { |iteration| num % iteration == 0 }.reduce(:+)
	end
end
