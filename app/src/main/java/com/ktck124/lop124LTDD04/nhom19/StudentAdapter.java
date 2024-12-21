package com.ktck124.lop124LTDD04.nhom19;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

public class StudentAdapter extends BaseAdapter {

    private Context context;
    private List<Student> studentList;
    private LayoutInflater inflater;

    public StudentAdapter(Context context, List<Student> studentList) {
        this.context = context;
        this.studentList = studentList;
        this.inflater = LayoutInflater.from(context);
    }

    @Override
    public int getCount() {
        return studentList.size();
    }

    @Override
    public Object getItem(int position) {
        return studentList.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        ViewHolder holder;

        if (convertView == null) {
            convertView = inflater.inflate(R.layout.item, parent, false);
            holder = new ViewHolder();

            holder.imgAvatar = convertView.findViewById(R.id.img_avatar);
            holder.tvName = convertView.findViewById(R.id.student_name);
            holder.tvEmail = convertView.findViewById(R.id.student_email);
            holder.tvStudentId = convertView.findViewById(R.id.student_msv);
            holder.tvClassId = convertView.findViewById(R.id.student_lop);

            convertView.setTag(holder);
        } else {
            holder = (ViewHolder) convertView.getTag();
        }


        Student student = studentList.get(position);


        holder.tvName.setText(student.getName());
        holder.tvEmail.setText("Email: " + student.getEmail());
        holder.tvStudentId.setText("MSV: " + student.getStudentId());
        holder.tvClassId.setText("Lớp: " + student.getClassId());
        holder.imgAvatar.setImageResource(R.drawable.icon_account);

        return convertView;
    }

    private static class ViewHolder {
        ImageView imgAvatar;
        TextView tvName;
        TextView tvEmail;
        TextView tvStudentId;
        TextView tvClassId;
    }
}

