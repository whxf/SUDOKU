/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sudoku;

/**
 *
 * @author whxf
 */
public class SUDOKU {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        MainFrame frame = new MainFrame();
        frame.setVisible(true);
        frame.validate();
        
        frame.addWindowListener(new java.awt.event.WindowAdapter() {  
            public void windowClosing(java.awt.event.WindowEvent e){  
                System.exit(0);
            }
        });
        // TODO code application logic here
    }
    
}
