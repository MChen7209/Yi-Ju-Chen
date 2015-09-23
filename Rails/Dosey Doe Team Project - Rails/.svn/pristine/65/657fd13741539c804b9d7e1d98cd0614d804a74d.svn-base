require 'os'

$master_report_path = '../CoverageTestReport.html'

$coverage_tools = [
  {
    name: 'SimpleCov',
    desc: 'Ruby/Rails',
    report_file_name: './coverage/index.html',
    covered_lines_location: { line: 36, pattern: /<|>/, index: 4 },
    total_lines_location: { line: 35, pattern: /<|>/, index: 2 },
    stats_ready: false
  },
  {
    name: 'Teaspoon',
    desc: 'JavaScript',
    report_file_name: './coverage-js/default/index.html',
    covered_lines_location: { line: 21, pattern: /\(|\)|\W/, index: 14 },
    total_lines_location: { line: 21, pattern: /\(|\)|\W/, index: 17 },
    stats_ready: false
  }
]

class CoverageMaster
  def self.reports_ready?
    $coverage_tools.map { |t| File.file?(t[:report_file_name]) } .any?
  end

  def self.open_all_reports
    $coverage_tools.each do |tool|
      if File.file?(tool[:report_file_name])
        system("#{OS.open_file_command} #{tool[:report_file_name]}")
      end
    end
  end

  def self.open_master_report
    generate_master_report unless File.file?($master_report_path)
    system("#{OS.open_file_command} #{master_report_path}")
  end

  def self.generate_master_report
    fetch_all_stats unless $coverage_tools[0][:stats_ready]

    report = File.open($master_report_path, 'w')

    report.puts <<-'header_end'
<html>
<head><title>Coverage Master Report</title></head>
<body style="font-family:sans-serif">
<h1>Coverage Master Report</h1>
<table border=2 cellpadding=10 style="font-size:110%">
<tr style="background:#EEEEEE"><th>Report source</th>
<th>Description</th>
<th>Number of tests</th>
<th>Covered / total lines</th>
<th>Coverage percentage</th></tr>
    header_end

    $coverage_tools.each do |tool|
      report.puts <<-row_end
<tr><td><a href='#{File.absolute_path(tool[:report_file_name])}'>#{tool[:name]}</a>
<td>#{tool[:desc]}
<td style="text-align:right">#{tool[:test_count]}
<td style="text-align:right">#{tool[:covered_lines]} / #{tool[:total_lines]}
<td style="text-align:right">#{percent(tool[:covered_lines], tool[:total_lines])}</tr>
      row_end
    end

    test_count_sum = $coverage_tools.map{|t| t[:test_count]}.reduce(:+)
    covered_lines_sum = $coverage_tools.map{|t| t[:covered_lines]}.reduce(:+)
    total_lines_sum = $coverage_tools.map{|t| t[:total_lines]}.reduce(:+)

    report.puts <<-total_end
<tr style="font-weight:bold">
<td colspan=2 style="background:#EEEEEE;text-align:center">Total
<td style="text-align:right">#{$coverage_tools.map{|t| t[:test_count]}.reduce(:+)}
<td style="text-align:right">#{covered_lines_sum} / #{total_lines_sum}
<td style="text-align:right">#{percent(covered_lines_sum, total_lines_sum)}
    total_end

    report.puts <<-'closing_end'
</table>
</body>
</html>
    closing_end

    report.close

    puts "Saved Coverage Master report to #{File.absolute_path($master_report_path)}"
  end

  def self.coverage_summary
    fetch_all_stats unless $coverage_tools[0][:stats_ready]

    result = '-------- TOTAL COVERAGE SUMMARY --------'.center(col_width * 4) + "\n"
    result += 'Source'.ljust(col_width)
    result += 'Desc.'.ljust(col_width)
    result += '# tests'.ljust(col_width)
    result += 'Line covrg.'.ljust(col_width)
    result += '% coverage'.ljust(col_width)
    result += "\n"

    $coverage_tools.each do |tool|
      result += tool[:name].ljust(col_width)
      result += tool[:desc].ljust(col_width)

      result += tool[:test_count].to_s.center(col_width)

      if tool[:total_lines] == 0
        result += missing_data
      else
        result += frac_and_percent(tool[:covered_lines], tool[:total_lines])
      end
    end

    result += '---- TOTAL ----'.center(col_width * 2)

    test_count_sum = $coverage_tools.map{|t| t[:test_count]}.reduce(:+)
    covered_lines_sum = $coverage_tools.map{|t| t[:covered_lines]}.reduce(:+)
    total_lines_sum = $coverage_tools.map{|t| t[:total_lines]}.reduce(:+)

    result += test_count_sum.to_s.center(col_width)

    if total_lines_sum == 0
      result += missing_data
    else
      result += frac_and_percent(covered_lines_sum, total_lines_sum)
    end

    result
  end

  def self.fetch_all_stats
    $coverage_tools.each do |tool|
      tool[:test_count] = 0
      tool[:covered_lines] = open_jump_split_index(
        tool[:report_file_name],
        tool[:covered_lines_location][:line],
        tool[:covered_lines_location][:pattern],
        tool[:covered_lines_location][:index]
      )
      tool[:total_lines] = open_jump_split_index(
        tool[:report_file_name],
        tool[:total_lines_location][:line],
        tool[:total_lines_location][:pattern],
        tool[:total_lines_location][:index]
      )
      tool[:stats_ready] = true
    end
  end

  def self.col_width
    12
  end

  def self.missing_data
    '( missing or parse error )'.center(col_width * 2) + "\n"
  end

  def self.frac_and_percent(covered, total)
    result = "#{covered}".rjust(col_width / 3)
    result += '/'.center(col_width / 3)
    result += "#{total}".rjust(col_width / 3)
    result += "#{percent(covered, total)}".rjust(col_width) + "\n"
    result
  end

  def self.open_jump_split_index(file_name, line_number, pattern, index)
    return 0 unless File.file?(file_name)

    file = File.open(file_name, 'r')
    line = ''
    line_number.times { line = file.gets }

    line.lstrip!.split(pattern)[index].to_i
  end

  def self.percent(covered, total)
    "#{(covered.to_f * 100 / total).round(2)}%"
  end
end
