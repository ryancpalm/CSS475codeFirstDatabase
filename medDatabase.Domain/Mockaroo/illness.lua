local base = "F:\\Code\\GitHub\\CSS475codeFirstDatabase\\medDatabase.Domain\\Mockaroo\\"
local inPath = base .. "Medical Histories.json"
local outPath = base .. "medical_histories.txt"

local function readMedicalHistories()
	local medicalHistories = {}
	for line in io.lines(inPath) do
		table.insert(medicalHistories, line)
	end
	return medicalHistories
end

local function getMedicalHistoryKey(medicalHistory)
	local key = medicalHistory:match("(\"PatientId\":%d+,\"IllnessId\":%d+)")
	return key
end

local function removeDuplicateMedicalHistories(medicalHistories)
	local uniques = {}
	local duplicates = {}
	for _, history in pairs(medicalHistories) do
		local key = getMedicalHistoryKey(history)
		if uniques[key] and not duplicates[key] then
			print("Duplicate entry with key: " .. key)
			duplicates[key] = true
		elseif not uniques[key] then
			uniques[key] = history
		end
	end
	local uniqueHistories = {}
	for uniqueKey, history in pairs(uniques) do
		table.insert(uniqueHistories, history)
	end
	return uniqueHistories
end

local function writeTableToFile(tbl, path)
	local fileHandle = io.open(path, 'w')
	for _, value in pairs(tbl) do
		fileHandle:write(value .. "\n")
	end
	fileHandle:close()
end

local histories = readMedicalHistories()
local uniqueHistories = removeDuplicateMedicalHistories(histories)
writeTableToFile(uniqueHistories, outPath)
