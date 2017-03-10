var students = [];

function displayStudent(student) {
    $('#students-list').append('<tr><td>' + student.fio +
        '</td><td>' + student.group +
        '</td><td>' + moment(student.dateBirth).format('DD.MM.YYYY') +
        '</td><td>' + student.specCode +
        '</td><td>' + student.recBookNum +
        '</td><td><a href="javascript:removeStudent(\'' + student.recBookNum + '\')">Удалить</a></td></tr>');
}

function displayAllStudents() {
    for (var i = 0; i < students.length; i++) {
        displayStudent(students[i]);
    }
}

function clearStudent(listNum) {
    $('#students-list tr:nth-child(' + listNum + ')').remove();
}

function clearStudents() {
    $('#students-list tr').remove();
}

function addStudent(surname, name, patronymic, group, dateBirth, specCode) {
    if (!dateBirth) {
        throw new Error('У студента не указана дата рождения');
    }

    var student = {
        surname: surname,
        name: name,
        patronymic: patronymic,
        fio: surname + ' ' + name + ' ' + patronymic,
        group: group,
        dateBirth: moment(dateBirth).isValid() ? moment(dateBirth).toDate() : moment(dateBirth, 'DD.MM.YYYY').toDate(),
        specCode: specCode
    };

    var recBookNum = getRecordBookNum(student);
    student.recBookNum = recBookNum;

    students.push(student);

    saveStudentsToLocalStore();
    displayStudent(student);
}

function removeStudent(recBookNum) {
    var listNum = -1;

    for (var i = 0; i < students.length; i++) {
        if (students[i].recBookNum === recBookNum) {
            listNum = i;
            break;
        }
    }

    if (listNum > -1) {
        students.splice(listNum, 1);

        saveStudentsToLocalStore();
        clearStudent(listNum + 1);
    } else {
        console.warn('При удалении студента был указан неверный код зачетки студента: "' + recBookNum + '"')
    }
}

function removeAllStudents() {
    if (students.length > 0) {
        students.splice(0, students.length);

        saveStudentsToLocalStore();
        clearStudents();
    }
}

function getRecordBookNum(student) {
    var specCode = student.specCode;
    if (!student.surname || !student.name || !student.patronymic) {
        throw new Error('У студента не указано полное ФИО');
    }

    if (!moment(student.dateBirth).isValid()) {
        throw new Error('У студента указана некорректная дата рождения');
    }

    var s1 = student.surname.substr(0, 1);
    var s2 = student.name.substr(0, 1);
    var s3 = student.patronymic.substr(0, 1);
    var monthNum = (student.dateBirth.getMonth() + 1).toString();
    var dayNum = student.dateBirth.getDate().toString();
    var suff = monthNum + dayNum;
    return specCode + '-' + s1 + s2 + s3 + suff;
}

function saveStudentsToLocalStore() {
    if (localStorage) {
        var studentsJSON = JSON.stringify(students);
        localStorage.setItem('students', studentsJSON);
    }
}

function loadStudentsFromLocalStore() {
    if (localStorage) {
        var studentsJSON = localStorage.getItem('students');
        if (studentsJSON) {
            students = JSON.parse(studentsJSON, function (key, value) {
                if (key === 'dateBirth') return new Date(value);
                return value;
            });
        }
    }
}
