import java.util.Scanner;

public class Clock {
    private int sec;
    private int min;
    private int hour;
    private String amPm = "AM";
    
    public void increment() {
        sec++;
        if (sec == 60) {
            sec = 0;
            min++;
        }
        if (min == 60) {
            min = 0;
            hour++;
        }
        if (hour == 13) {
            hour = 1;
            amPm = amPm.equals("AM") ? "PM" : "AM";
        }
    }
    
    public void reset() {
        sec = 0;
        min = 0;
        hour = 0;
    }
    
    public int getSeconds() { return sec; }
    public int getMinutes() { return min; }
    public int getHours() { return hour; }
    public String getAmPm() { return amPm; }
    
    public static void main(String[] args) {
        Clock clock = new Clock();
        Scanner scanner = new Scanner(System.in);
        
        Thread resetListener = new Thread(() -> {
            while (scanner.hasNext()) {
                if (scanner.next().equalsIgnoreCase("R")) {
                    clock.reset();
                }
            }
        });
        resetListener.setDaemon(true);
        resetListener.start();
        
        Runtime runtime = Runtime.getRuntime();
        
        while (true) {
            System.out.printf("Counting: %02d:%02d:%02d %s\n", clock.getHours(), clock.getMinutes(), clock.getSeconds(), clock.getAmPm());
            System.out.println("Press 'R' to reset");
            
            // Get the total memory available to the JVM in bytes
            long totalMemory = runtime.totalMemory();
            // Get the free memory available to the JVM in bytes
            long freeMemory = runtime.freeMemory();
            // Calculate the used memory in bytes
            long usedMemory = totalMemory - freeMemory;
            System.out.println("Used Memory: " + usedMemory + " bytes");
            
            clock.increment();
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                System.err.println("Thread was interrupted: " + e.getMessage());
            }
        }
    }
}
