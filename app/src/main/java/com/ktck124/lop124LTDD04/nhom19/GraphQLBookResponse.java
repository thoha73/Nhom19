package com.ktck124.lop124LTDD04.nhom19;
import com.google.gson.annotations.SerializedName;
import com.google.gson.internal.LinkedTreeMap;

import java.util.List;

public class GraphQLBookResponse {

    @SerializedName("bookById")
    private LinkedTreeMap<String, Object> bookById;

    private List<com.ktck124.lop124LTDD04.nhom19.Book> books;

    public LinkedTreeMap<String, Object> getBookById() {
        return bookById;
    }

    public void setBookById(LinkedTreeMap<String, Object> bookById) {
        this.bookById = bookById;
    }

    public List<com.ktck124.lop124LTDD04.nhom19.Book> getBooks() {
        return books;
    }

    public void setBooks(List<com.ktck124.lop124LTDD04.nhom19.Book> books) {
        this.books = books;
    }
}