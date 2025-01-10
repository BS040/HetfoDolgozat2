
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.*;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class VikingLottoGUI extends JFrame {
    private final List<JCheckBox> checkBoxes = new ArrayList<>();
    private final JButton drawButton = new JButton("Sorsolás");
    private final JButton exitButton = new JButton("Kilépés");
    private final JLabel resultLabel = new JLabel("Válassz ki 6 számot!");

    public VikingLottoGUI() {
        setTitle("Viking Lotto Sorsolás");
        setSize(400, 500);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new BorderLayout());

        JPanel gridPanel = new JPanel(new GridLayout(8, 6));
        for (int i = 1; i <= 48; i++) {
            JCheckBox checkBox = new JCheckBox(String.valueOf(i));
            checkBoxes.add(checkBox);
            gridPanel.add(checkBox);
            checkBox.addActionListener(e -> updateDrawButtonState());
        }
        add(gridPanel, BorderLayout.CENTER);

        JPanel buttonPanel = new JPanel();
        drawButton.setEnabled(false);
        buttonPanel.add(drawButton);
        buttonPanel.add(exitButton);
        add(buttonPanel, BorderLayout.SOUTH);

        resultLabel.setHorizontalAlignment(SwingConstants.CENTER);
        resultLabel.setFont(new Font("Arial", Font.PLAIN, 14));
        add(resultLabel, BorderLayout.NORTH);

        exitButton.addActionListener(e -> System.exit(0));
        drawButton.addActionListener(new DrawButtonListener());
    }

    private void updateDrawButtonState() {
        long selectedCount = checkBoxes.stream().filter(AbstractButton::isSelected).count();
        drawButton.setEnabled(selectedCount == 6);
    }

    private class DrawButtonListener implements ActionListener {
        @Override
        public void actionPerformed(ActionEvent e) {
            List<Integer> selectedNumbers = new ArrayList<>();
            for (JCheckBox checkBox : checkBoxes) {
                if (checkBox.isSelected()) {
                    selectedNumbers.add(Integer.parseInt(checkBox.getText()));
                }
            }

            List<Integer> drawnNumbers = new ArrayList<>();
            for (int i = 1; i <= 48; i++) {
                drawnNumbers.add(i);
            }
            Collections.shuffle(drawnNumbers);
            drawnNumbers = drawnNumbers.subList(0, 6);

            long matches = selectedNumbers.stream().filter(drawnNumbers::contains).count();

            resultLabel.setText("Találatok száma: " + matches + " / 6");
            saveDrawnNumbersToDatabase(drawnNumbers);
        }
    }

    private void saveDrawnNumbersToDatabase(List<Integer> drawnNumbers) {
        String url = "jdbc:mysql://localhost:3306/VikingLotto";
        String user = "root"; 
        String password = ""; 

        try (Connection conn = DriverManager.getConnection(url, user, password)) {
            String sql = "INSERT INTO DrawnNumbers (number1, number2, number3, number4, number5, number6) "
                       + "VALUES (?, ?, ?, ?, ?, ?)";
            PreparedStatement stmt = conn.prepareStatement(sql);

            for (int i = 0; i < drawnNumbers.size(); i++) {
                stmt.setInt(i + 1, drawnNumbers.get(i));
            }
            stmt.executeUpdate();
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(this, "Hiba az adatbázis mentés során: " + e.getMessage(),
                    "Adatbázis hiba", JOptionPane.ERROR_MESSAGE);
        }
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> new VikingLottoGUI().setVisible(true));
    }
}
