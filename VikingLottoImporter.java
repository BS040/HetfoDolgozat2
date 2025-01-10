
import java.io.*;
import java.sql.*;
import java.util.*;

public class VikingLottoImporter {
    public static void main(String[] args) {
        // Ellenőrzés: Van-e megadott fájl paraméter
        if (args.length != 1) {
            System.out.println("Használat: java VikingLottoImporter <CSV fájl útvonala>");
            return;
        }

        String csvFile = args[0];
        List<int[]> validRows = new ArrayList<>();
        int invalidCount = 0;

        // CSV fájl feldolgozása
        try (BufferedReader br = new BufferedReader(new FileReader(csvFile))) {
            String line;
            while ((line = br.readLine()) != null) {
                String[] values = line.split(";");
                if (values.length != 6) {
                    invalidCount++;
                    continue;
                }

                try {
                    int[] numbers = Arrays.stream(values)
                                          .mapToInt(Integer::parseInt)
                                          .toArray();

                    if (Arrays.stream(numbers).allMatch(n -> n >= 1 && n <= 48)) {
                        validRows.add(numbers);
                    } else {
                        invalidCount++;
                    }
                } catch (NumberFormatException e) {
                    invalidCount++;
                }
            }
        } catch (IOException e) {
            System.err.println("Hiba a fájl megnyitásakor: " + e.getMessage());
            return;
        }

        System.out.println("Érvényes sorok: " + validRows.size());
        System.out.println("Érvénytelen sorok: " + invalidCount);

        // Adatok beszúrása adatbázisba
        String url = "jdbc:mysql://localhost:3306/VikingLotto";
        String user = "root"; // Cseréld ki a megfelelő felhasználónévre
        String password = ""; // Cseréld ki a megfelelő jelszóra

        try (Connection conn = DriverManager.getConnection(url, user, password)) {
            String sql = "INSERT INTO ImportedNumbers (number1, number2, number3, number4, number5, number6) "
                       + "VALUES (?, ?, ?, ?, ?, ?)";
            PreparedStatement stmt = conn.prepareStatement(sql);

            for (int[] row : validRows) {
                for (int i = 0; i < row.length; i++) {
                    stmt.setInt(i + 1, row[i]);
                }
                stmt.addBatch();
            }

            int[] results = stmt.executeBatch();
            System.out.println("Sikeresen importált rekordok: " + results.length);
        } catch (SQLException e) {
            System.err.println("Hiba az adatbázis-művelet során: " + e.getMessage());
        }
    }
}
