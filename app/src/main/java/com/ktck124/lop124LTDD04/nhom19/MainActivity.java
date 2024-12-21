package com.ktck124.lop124LTDD04.nhom19;

import android.os.Bundle;
import android.widget.ListView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    private ListView listView;
    private List<Student> studentList;
    private StudentAdapter adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.info);


        listView = findViewById(R.id.listView_std);


        studentList = new ArrayList<>();
        studentList.add(new Student("Trần Thanh Vỹ", "22115053122251@sv.ute.udn.vn", "22115053122251", "22T2"));
        studentList.add(new Student("Nguyễn Thọ Hà", "22115053122252@sv.ute.udn.vn", "2211505312225", "22T3"));
        studentList.add(new Student("Võ Vĩ Khương", "22115053122253@sv.ute.udn.vn", "22115053122253", "22T3"));


        adapter = new StudentAdapter(this, studentList);


        listView.setAdapter(adapter);
    }
}
