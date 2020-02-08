<template>
    <div>
        <h1 class="table_heading">Students</h1>
        <table>
            <thead>
                <tr>
                    <th>Student Id</th>
                    <th>Email Address</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="student in students" v-bind:key="student">
                    <td>{{ student.studentId }}</td>
                    <td>{{ student.email }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
  name: 'Students',
  mounted() {
      this.students = getStudents();
  },
  data () {
      return {
          students: []
      }
  }
}

function getStudents() {
    return JSON.parse(students);
}

var students = '[{"studentId": 12345, "email": "jake.student@oit.edu"}, {"studentId": 23456, "email": "david.student@oit.edu"}, {"studentId": 34567, "email": "brad.student@oit.edu"}, {"studentId": 45678, "email": "andrew.student@oit.edu"}, {"studentId": 56789, "email": "nick.student@oit.edu"}]';
</script>

<style scoped>
.table_heading {
    font-size: xx-large;
    background-color: cadetblue;
}

table, tr, td, th {
    padding: 5px;
    text-align: left;
    border: 1px solid black;
}
</style>