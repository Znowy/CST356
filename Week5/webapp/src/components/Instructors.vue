<template>
    <div>
        <h1 class="table_heading">Instructors</h1>
        <table>
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Middle Initial</th>
                    <th>Last Name</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="instructor in instructors" v-bind:key="instructor">
                    <td>{{ instructor.first }}</td>
                    <td>{{ instructor.middle }}</td>
                    <td>{{ instructor.last }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
  name: 'Instructors',
  mounted() {
      this.instructors = getInstructors();
  },
  data () {
      return {
          instructors: []
      }
  }
}

function getInstructors() {
    return JSON.parse(instructors);
}

var instructors = '[{"first": "Phong", "middle": "A", "last": "Nguyen"}, {"first": "Sherry", "middle": "B", "last": "Yang"}, {"first": "Gerald", "middle": "C", "last": "Aden"}, {"first": "Heath", "middle": "D", "last": "Higgins"}, {"first": "Lucas", "middle": "E", "last": "Cordova"}]';
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