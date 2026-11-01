import java.util.List;

public class Main {
    public static void main(String[] args) {
        List<Person> people = List.of(
            new Person("Chad", 8),
            new Person("Kate", 54),
            new Person("Silky", 12)
        );

        List<String> kids = people.stream()
            .filter(p -> p.getAge() < 18)
            .map(Person::getName)
            .toList();

        System.out.println(kids);
    }
}