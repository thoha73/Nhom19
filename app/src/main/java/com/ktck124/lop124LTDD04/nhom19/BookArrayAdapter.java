package com.ktck124.lop124LTDD04.nhom19;

import android.app.Activity;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.util.Base64;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;
import java.util.List;

public class BookArrayAdapter extends ArrayAdapter<Book> {
    Activity context;
    int idLayout;
    boolean isGridView3;
    ArrayList<Book> listBook;
    public BookArrayAdapter(Activity context, int idLayout, ArrayList<Book> listBook,boolean isGridView3) {
        super(context, idLayout, listBook);
        this.context = context;
        this.idLayout = idLayout;
        this.listBook = listBook;
        this.isGridView3 = isGridView3;

    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        LayoutInflater myflater= context.getLayoutInflater();
        convertView = myflater.inflate(idLayout, null);
//        int width=parent.getWidth()/3;
//        convertView.setLayoutParams(new GridView.LayoutParams(width,GridView.AUTO_FIT));
        Book book = listBook.get(position);
        ImageView imageView=convertView.findViewById(R.id.imageView);
        if (book.getImages() != null && !book.getImages().isEmpty()) {
            String imageData = book.getImages().get(0).getImageData();
            Log.d("ImageData", "Image Data: " + imageData);
            Bitmap bitmap = decodeBase64ToBitmap(imageData);
            if (bitmap != null) {
                imageView.setImageBitmap(bitmap);
            } else {
                imageView.setImageResource(R.drawable.book4);
            }
        }
        TextView textView=convertView.findViewById(R.id.textView);
        if (isGridView3) {

            String categoryName = getCategoryNameFromBook(book);  // Giả sử bạn có thể lấy categoryId từ sách
            textView.setText(categoryName);
        } else {
            textView.setText(book.getBookName());
        }

        return convertView;
    }
    private String getCategoryNameFromBook(Book book) {
        if (book.getCategories() != null && !book.getCategories().isEmpty()) {
            return (String) book.getCategories().get(0).getCategoryName();
        }
        return "No Category";
    }
    private Bitmap decodeBase64ToBitmap(String base64String) {
        try {
            byte[] decodedString = Base64.decode(base64String, Base64.DEFAULT);
            return BitmapFactory.decodeByteArray(decodedString, 0, decodedString.length);
        } catch (IllegalArgumentException e) {
            Log.e("Base64", "Invalid Base64 string", e);
            return null;
        }
    }
}
