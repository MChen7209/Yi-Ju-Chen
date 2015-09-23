class PerfectNumberFinderImperative
	def self.isPerfectNumber(num)
		num > 1 && sumOfFactors(num) == num
	end

	def self.sumOfFactors(num)
		sum = 0
		for index in 1..num-1
			sum += index if num % index == 0
		end
		sum
	end
end