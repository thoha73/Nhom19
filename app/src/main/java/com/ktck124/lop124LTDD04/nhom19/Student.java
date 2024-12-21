package com.ktck124.lop124LTDD04.nhom19;

public class Student {
    private String name;
    private String email;
    private String studentId;
    private String classId;

    public Student(String name, String email, String studentId, String classId) {
        this.name = name;
        this.email = email;
        this.studentId = studentId;
        this.classId = classId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getStudentId() {
        return studentId;
    }

    public void setStudentId(String studentId) {
        this.studentId = studentId;
    }

    public String getClassId() {
        return classId;
    }

    public void setClassId(String classId) {
        this.classId = classId;
    }
}

