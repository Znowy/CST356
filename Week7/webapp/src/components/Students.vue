<template>
    <div>
        <div v-if='operation == "list"'>
            <h2 class='section-heading'>Students</h2>
            <table>
                <thead>
                    <tr>
                        <th>Email Address</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="student in students" :key="student.studentId">
                        <td>{{ student.email }}</td>
                        <td>
                            <button v-on:click='displayStudentDetails(student.studentId)'>Details</button>
                            <button v-on:click='displayUpdateStudent(student.studentId)'>Update</button>
                            <button v-on:click='deleteStudent(student.studentId)'>Delete</button>
                        </td>
                    </tr>
                </tbody>
            </table>

            <button id='addBtn' v-on:click='displayAddStudent()'>Add Student</button>
        </div>

        <div v-if='operation == "add"'>
            <h2 class='section-heading'>Add Student</h2>
        
            <form>
                <div class='form-entry'>
                    email: <input type='text' v-model='email'/>
                </div>

                <div class='form-entry'>
                    <button v-on:click='addstudent'>Add Student</button>
                    <button v-on:click='cancel'>Cancel</button>
                </div>
            </form>

        </div>

        <div v-if='operation == "detail"'>
            <h2 class='section-heading'>Student Detail</h2>

            <div class='form-entry'>
                email: {{ email }}
            </div>

            <div class='form-entry'>
                <button v-on:click='cancel'>Ok</button>
            </div>
        </div>

        <div v-if='operation == "update"'>
            <h2 class='section-heading'>Update Student</h2>
        
            <form>
                <div class='form-entry'>
                    email: <input type='text' v-model='email'/>
                </div>

                <div class='form-entry'>
                    <button v-on:click='updateStudent'>Update Student</button>
                    <button v-on:click='cancel'>Cancel</button>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
    import Vue from 'vue';
    export default {
        name: 'Students',
        
        data () {
            return {
                students: [],
                operation: 'list',
                email: undefined,
                studentUpdateId: undefined,
                apiServer: process.env.VUE_APP_API_SERVER
            }
        },
        methods: {
            getStudents: function() {
                let url = `http://${this.apiServer}/api/student`;
                Vue.axios.get(url).then(
                    (response) => {
                        this.students = response.data;
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            getStudent: function(studentId) {
                let url = `http://${this.apiServer}/api/student/${studentId}`;
                Vue.axios.get(url).then(
                    (response) => {
                        this.email = response.data.email;
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            displayAddStudent: function() {
                this.email = undefined;
                this.operation = 'add';
            },
            addStudent: function() {
                let url = `http://${this.apiServer}/api/student`;
                Vue.axios.post(url, {
                    email: this.email
                }).then(
                    () => {
                        this.getStudents();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            displayStudentDetails: function(studentId) {
                this.getStudent(studentId);
                this.operation = 'detail';
            },
            displayUpdateStudent: function(studentId) {
                this.studentUpdateId = studentId;
                this.getStudent(studentId);
                this.operation = 'update';
            },
            updateStudent: function() {
                let url = `http://${this.apiServer}/api/student/${this.studentUpdateId}`;
                Vue.axios.put(url, {
                    email: this.email
                }).then(
                    () => {
                        this.getStudents();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            deleteStudent: function(studentId) {
                let url = `http://${this.apiServer}/api/student/${studentId}`;
                Vue.axios.delete(url).then(
                    () => {
                        this.getStudents();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            cancel: function() {
                this.operation = 'list';
            }
        },
        mounted() {
            this.getStudents();
            this.operation = 'list';
        }
    }
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